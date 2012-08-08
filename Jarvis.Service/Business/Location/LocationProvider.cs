using System;

namespace Jarvis.Service.Business.Location
{
    public class LocationProvider : ILocationProvider
    {
        private ISensorDatasProvider _sdp;

        public LocationProvider(ISensorDatasProvider sdp)
        {
            if (sdp == null) throw new ArgumentNullException("sdp","ISensorDataProvider dependency should be provided");
            _sdp = sdp;
        }

        #region Implementation of ILocationProvider

        /// <summary>
        /// Location object referring to the location the agent is currently
        /// in (not stored in the db of known locations) all fields are not populated
        /// </summary>
        public Domain.Location.Location CurrentLocation
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Location object referring to the best fitting location present in the db.
        /// </summary>
        public Domain.Location.Location ComputedLocation
        {
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Stores the location object in the db of known locations
        /// </summary>
        /// <param name="location">location object to store, required fields should be populated</param>
        public void StoreAsKnownLocation(Domain.Location.Location location)
        {
            throw new System.NotImplementedException();
        }

        #endregion


        
    }
}