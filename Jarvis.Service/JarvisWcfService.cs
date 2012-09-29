using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using Jarvis.Service.Business.Location;
using Jarvis.WCF.Contracts.Data;
using DTO = Jarvis.WCF.Contracts.Data;
using Domain = Jarvis.Service.Domain;
using DataContracts = Jarvis.WCF.Contracts.Data;
using Jarvis.WCF.Contracts.Service;

namespace Jarvis.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class JarvisWcfService : ILocationService
    {
        private readonly ILocationProvider _locationProvider;
        private readonly IMappingEngine _mapper;

        public JarvisWcfService(ILocationProvider locationProvider, IMappingEngine mapper)
        {
            this._locationProvider = locationProvider;
            _mapper = mapper;
        }

        #region Implementation of ILocationService

        public IList<DataContracts.Location> GetKnownLocations()
        {
            return _locationProvider.KnownLocations
                .Select<Domain.Location.Location, DataContracts.Location>(
                    l =>
                        {
                            var mapped = _mapper.Map<DataContracts.Location>(l);
                            mapped.Score =
                                l.LocationSensorDatas.DistanceFrom(_locationProvider.CurrentLocation.LocationSensorDatas);
                            return mapped;
                        }).ToList();
        }

        public DataContracts.Location GetCurrentLocation()
        {
            return _mapper.Map<DataContracts.Location>(_locationProvider.ComputedLocation);
        }

        public void StoreCurrentLocation(DataContracts.Location location)
        {
            var l = _mapper.Map<Domain.Location.Location>(location);

            _locationProvider.StoreAsKnownLocation(l);
        }

        public void RemoveLocation(Location location)
        {
            var l = _mapper.Map<Domain.Location.Location>(location);

            _locationProvider.RemoveLocation(l);
        }

        public void UpdateLocation(Location location)
        {
            var l = _mapper.Map<Domain.Location.Location>(location);

            _locationProvider.UpdateLocation(l);
        }

        #endregion
    }
}
