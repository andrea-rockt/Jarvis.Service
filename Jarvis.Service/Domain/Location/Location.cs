using System;
using System.Collections.Generic;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class Location : Entity<Guid>
    {
        

        public virtual LocationSensorDatas LocationSensorDatas { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string StreetAddress { get; protected set; }

        public virtual string City { get; protected set; }

        public virtual string State { get; protected set; }

        public virtual IList<LocationCategory> Categories { get; protected set; } 
    }

}
