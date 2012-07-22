using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class MacAddress : Entity<Guid>
    {
        public virtual byte[] Bytes { get; protected set; }
        public override string ToString()
        {
            throw new NotImplementedException();
            return base.ToString();
        }
    }
}
