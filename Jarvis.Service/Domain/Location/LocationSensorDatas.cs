using System;
using System.Collections;
using System.Collections.Generic;
using Jarvis.Service.Domain.DomainModel;
using System.Linq;
namespace Jarvis.Service.Domain.Location
{
    public class LocationSensorDatas : Entity<Guid>, IBusinessEquatable
    {
        public virtual IList<SensorData> SensorDatas { get; set; }

        public virtual double DistanceFrom(LocationSensorDatas other)
        {
            double distance = 0;
            foreach (var s1 in SensorDatas)
            {
                foreach (var s2 in other.SensorDatas)
                {
                    distance += 1-s1.SquaredDistanceFrom(s2);
                }
            }

            //distance = Math.Sqrt(distance);
            return 1 - Math.Sqrt(distance/Math.Min(SensorDatas.Count,other.SensorDatas.Count));
        }


        public virtual bool BusinessEquals(LocationSensorDatas other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;


            IEnumerable<SensorData> sensorDatas = from s in SensorDatas
                                                  where other.SensorDatas.Any((x) => x.BusinessEquals(s))
                                                  select s;

            return sensorDatas.Count() == other.SensorDatas.Count;
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
            return BusinessEquals(obj as LocationSensorDatas);
        }

    }
}
