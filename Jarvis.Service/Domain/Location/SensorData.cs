using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public abstract class SensorData :Entity<Guid>
    {      
        public abstract double SquaredDistanceFrom(SensorData other);
    }
}
