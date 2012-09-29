using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis.Service.Business.Location
{
    public interface ILocationProvider
    {
        /// <summary>
        /// Location object referring to the location the agent is currently
        /// in (not stored in the db of known locations) all fields are not populated
        /// </summary>
        Domain.Location.Location CurrentLocation { get; }
        /// <summary>
        /// Location object referring to the best fitting location present in the db.
        /// </summary>
        Domain.Location.Location ComputedLocation { get; }


        IList<Domain.Location.Location> KnownLocations { get; }
        /// <summary>
        /// Stores the location object in the db of known locations
        /// </summary>
        /// <param name="location">location object to store, required fields should be populated</param>
        void StoreAsKnownLocation(Domain.Location.Location location);


        void RemoveLocation(Domain.Location.Location location);

        void UpdateLocation(Domain.Location.Location location);
    }
}
