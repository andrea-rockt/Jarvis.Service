using System;
using System.Collections;
using System.Collections.Generic;
using Jarvis.Service.Domain.DomainModel;
using System.Linq;
namespace Jarvis.Service.Domain.Location
{
    public class LocationSensorDatas : Entity<Guid>,IBusinessEquatable
    {
        public virtual IList<SensorData> SensorDatas { get; set; }

        public virtual void DistanceFrom(LocationSensorDatas other)
        {
            throw new System.NotImplementedException();
        }


        public bool BusinessEquals(LocationSensorDatas other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;


            IEnumerable<SensorData> sensorDatas = from s in SensorDatas
                                                  where other.SensorDatas.Any((x) => x.BusinessEquals(s))
                                                  select s;

            return sensorDatas.Count()==other.SensorDatas.Count;
        }


        /// <summary>
        /// Checks Businness rule equivalence
        /// </summary>
        /// <param name="obj">Object to check for equivalence</param>
        /// <returns></returns>
        public  bool BusinessEquals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return BusinessEquals(obj as LocationSensorDatas);
        }

    }
}
