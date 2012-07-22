using System;
using System.Linq;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class MacAddress : Entity<Guid>
    {
        public virtual byte[] Bytes { get; set; }


        /// <summary>
        /// Check if object represents the same mac address inspite of ids
        /// </summary>
        /// <param name="other">Object to check for equivalence</param>
        /// <returns></returns>
        public virtual bool IsEquivalent(MacAddress other)
        {
            if (Bytes == null || other.Bytes == null)
                return false;

            return Bytes.SequenceEqual(other.Bytes);
        }

        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
