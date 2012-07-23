using System;
using System.Linq;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class MacAddress : Entity<Guid>,IBusinessEquatable
    {
        public virtual byte[] Bytes { get; set; }


        public virtual bool BusinessEquals(MacAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Bytes.SequenceEqual(other.Bytes);
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
            return BusinessEquals(obj as MacAddress);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
