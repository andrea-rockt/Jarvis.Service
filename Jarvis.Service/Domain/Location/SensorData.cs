using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public abstract class SensorData :Entity<Guid>, IBusinessEquatable
    {      
        public abstract double SquaredDistanceFrom(SensorData other);

        #region Implementation of IBusinessEquatable

        public abstract bool BusinessEquals(object other);

        #endregion
    }
}
