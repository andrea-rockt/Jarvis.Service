using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class LocationCategory:Entity<Guid>
    {
        public virtual string Name { get; protected set; }
    }
}
