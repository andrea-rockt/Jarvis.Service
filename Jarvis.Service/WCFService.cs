using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.WCF.Contracts.Data;
using Jarvis.WCF.Contracts.Service;

namespace Jarvis.Service
{
    public class WCFService : ILocationService
    {
        #region Implementation of ILocationService

        public IList<Location> GetKnownLocations()
        {
            return new List<Location>
                       {
                           new Location
                               {
                                   Categories = new List<LocationCategory>
                                                    {
                                                        new LocationCategory
                                                            {
                                                                Id = Guid.NewGuid()
                                                                ,Name = "Casa"
                                                            }
                                                    },
                                   City = "Catania",
                                   Id = Guid.NewGuid(),
                                   Name = "Locazione1",
                                   State = "Italy",
                                   StreetAddress = "Via Raffaele Leone 5"
                               },
                               new Location
                               {
                                   Categories = new List<LocationCategory>
                                                    {
                                                        new LocationCategory
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                Name = "Lavoro"
                                                            }
                                                    },
                                   City = "Giarre",
                                   Id = Guid.NewGuid(),
                                   Name = "Locazione2",
                                   State = "Italy",
                                   StreetAddress = "Via Raffaele Leone 5"
                               }
                       };
        }

        public Location GetCurrentLocation()
        {
            throw new NotImplementedException();
        }

        public void StoreCurrentLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public void RemoveLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public void UpdateLocation(Location location)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
