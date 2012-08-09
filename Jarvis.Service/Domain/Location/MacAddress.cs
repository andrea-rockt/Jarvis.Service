using System;
using System.Linq;
using System.Net.NetworkInformation;
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
            return String.Format("{0,2:X}:{1,2:X}:{2,2:X}:{3,2:X}:{4,2:X}:{5,2:X}", Bytes[0], Bytes[1], Bytes[2], Bytes[3], Bytes[4], Bytes[5]);
        }

        public static MacAddress FromPhysicalAddress(PhysicalAddress pa)
        {
            return new MacAddress() {Bytes = pa.GetAddressBytes()};
        }
    }
}
