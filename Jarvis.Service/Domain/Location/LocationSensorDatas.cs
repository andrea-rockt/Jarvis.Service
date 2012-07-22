using System;
using System.Collections.Generic;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class LocationSensorDatas:Entity<Guid>
    {
        public virtual IList<SensorData> SensorDatas { get; set; }

        public virtual void DistanceFrom(LocationSensorDatas other)
        {
            throw new System.NotImplementedException();
        }
    }
}
