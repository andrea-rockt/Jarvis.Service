using System;
using Jarvis.Service.Domain.Repos;
using System.Linq;
namespace Jarvis.Service.Business.Location
{
    public class LocationProvider : ILocationProvider
    {
        private ILocationRepository _locations;
        private ISensorDatasProvider _sdp;

        public LocationProvider(ISensorDatasProvider sdp, ILocationRepository locations)
        {
            if (sdp == null) throw new ArgumentNullException("sdp","ISensorDataProvider dependency should be provided");
            if (locations == null) throw new ArgumentNullException("locations", "Repository dependency should be provided");
            _sdp = sdp;
            _locations = locations;
        }

        #region Implementation of ILocationProvider

        /// <summary>
        /// Location object referring to the location the agent is currently
        /// in (not stored in the db of known locations) all fields are not populated
        /// </summary>
        public Domain.Location.Location CurrentLocation
        {
            get { 
                
                var sensorDatas = _sdp.GetCurrentSensorDatas();
                var location = new Domain.Location.Location() {LocationSensorDatas = sensorDatas};
                return location;
            }
        }

        /// <summary>
        /// Location object referring to the best fitting location present in the db.
        /// </summary>
        public Domain.Location.Location ComputedLocation
        {
            get
            {
                var currentLocation = CurrentLocation;

                var locations = from location in _locations.All()
                                orderby location.LocationSensorDatas.DistanceFrom(currentLocation.LocationSensorDatas) ascending 
                                select location;

                return locations.FirstOrDefault();
            }
        }

        /// <summary>
        /// Stores the location object in the db of known locations
        /// </summary>
        /// <param name="location">location object to store, required fields should be populated</param>
        public void StoreAsKnownLocation(Domain.Location.Location location)
        {
            _locations.Add(location);
        }

        #endregion


        
    }
}