using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class LocationCategory:Entity<Guid>,IBusinessEquatable
    {
        public virtual string Name { get; set; }

        public virtual bool BusinessEquals(LocationCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Name.Equals(other.Name);
        }


        /// <summary>
        /// Checks Businness rule equivalence
        /// </summary>
        /// <param name="obj">Object to check for equivalence</param>
        /// <returns></returns>
        public virtual bool BusinessEquals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return BusinessEquals(obj as LocationCategory);
        }

    }
}
