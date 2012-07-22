using System;
using System.Collections.Generic;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class Location : Entity<Guid>
    {
        

        public virtual LocationSensorDatas LocationSensorDatas { get;  set; }

        public virtual string Name { get;  set; }

        public virtual string StreetAddress { get;  set; }

        public virtual string City { get;  set; }

        public virtual string State { get;  set; }

        public virtual IList<LocationCategory> Categories { get;  set; } 
    }

}
