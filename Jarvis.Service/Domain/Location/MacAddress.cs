using System;
using System.Linq;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class MacAddress : Entity<Guid>
    {
        public virtual byte[] Bytes { get; set; }


        public bool IsEquivalent(MacAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Bytes.SequenceEqual(other.Bytes);
        }

        
        /// <summary>
        /// Checks Businness rule equivalence
        /// </summary>
        /// <param name="other">Object to check for equivalence</param>
        /// <returns></returns>
        public override bool IsEquivalent(Entity<Guid>obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return IsEquivalent(obj as MacAddress);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
