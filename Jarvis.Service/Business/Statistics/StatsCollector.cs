using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Domain.Repos;
using Jarvis.Service.Domain.Statistics;

namespace Jarvis.Service.Business.Statistics
{
    public class StatsCollector : IStatsCollector
    {
        private Thread _undeliyngThread = null;
        private ILocationStatsRepository _locationStats;
        private ILocationProvider _locationProvider;
        private bool _isCollecting = false;

        private object _syncObject = new object();

        private Domain.Location.Location _lastLocation = null;

        public TimeSpan CollectionPeriod { get; set; }

        public StatsCollector(ILocationStatsRepository locationStats, ILocationProvider locationProvider, TimeSpan collectionPeriod)
        {
            _locationStats = locationStats;
            _locationProvider = locationProvider;
            _undeliyngThread = new Thread(Run);
            CollectionPeriod = collectionPeriod;
        }


        private void Run()
        {
            while (IsCollecting)
            {
                Collect(DateTime.Now);
                Thread.Sleep((int)CollectionPeriod.TotalMilliseconds);
            }
        }

        internal void Collect(DateTime now)
        {
            if (_lastLocation == null)
            {
                _lastLocation = _locationProvider.ComputedLocation;
                if (_lastLocation != null)
                {
                    InsertOrUpdateLocationStats(now, _lastLocation, LocationStatsEntry.EntryKind.Enter);
                }
            }
            else
            {
                var location = _locationProvider.ComputedLocation;
                if (location != null)
                {
                    if (_lastLocation.Id!=location.Id)
                    {
                        InsertOrUpdateLocationStats(now, _lastLocation, LocationStatsEntry.EntryKind.Exit);
                        InsertOrUpdateLocationStats(now, location, LocationStatsEntry.EntryKind.Enter);
                    }
                    _lastLocation = location;
                }
            }
        }

        private void InsertOrUpdateLocationStats(DateTime now, Domain.Location.Location loc, LocationStatsEntry.EntryKind entryKind)
        {
            var persistedStat = (from l in _locationStats.All()
                                 where l.Location.Id == loc.Id
                                 select l).FirstOrDefault();

            if (persistedStat != null)
            {
                persistedStat.Entries.Add(new LocationStatsEntry { Date = now, Kind = entryKind });


                lock (_locationStats)
                {
                    _locationStats.Update(persistedStat);    
                }
                
            }
            else
            {
                persistedStat = new LocationStats
                                    {
                                        Entries = new List<LocationStatsEntry>
                                                      {
                                                          new LocationStatsEntry
                                                              {
                                                                  Date = now,
                                                                  Kind = entryKind
                                                              }
                                                      },
                                        Location = loc
                                    };
                lock(_locationStats){
                    _locationStats.Add(persistedStat);
                }
            }
        }

        #region Implementation of IStatsCollector

        public IList<LocationStats> GetAllStats()
        {
            lock (_locationStats)
            {
                return _locationStats.All().ToList();   
             }
            
        }

        public LocationStats StatsForLocation(Domain.Location.Location location)
        {
            lock (_locationStats)
            {
                return (from l in _locationStats.All()
                        where l.Location.Id == location.Id
                        select l).First();    
            }
            
        }

        public bool IsCollecting
        {
            get
            {
                lock (_syncObject)
                {
                    return _isCollecting;
                }
            }
            set
            {
                lock (_syncObject)
                {
                    _isCollecting = value;
                }
            }
        }

        public void StartCollecting()
        {
            if(_undeliyngThread.ThreadState==ThreadState.Stopped)
            {
                throw new InvalidOperationException(
                    "Collection was stopped, the state of this object is no longer valid");
            }
            IsCollecting = true;
            _undeliyngThread.Start();
        }

        public void StopCollecting()
        {
            if(!(_undeliyngThread.ThreadState == ThreadState.Running && _undeliyngThread.ThreadState == ThreadState.WaitSleepJoin))
            {
                throw new InvalidOperationException(
                    "Collection is not currently running");
            }
            IsCollecting = false;
            _undeliyngThread.Join();
        }

        #endregion
    }
}