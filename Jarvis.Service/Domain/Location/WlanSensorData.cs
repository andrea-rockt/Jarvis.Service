using System;
using System.Collections.Generic;
using System.Linq;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class WlanSensorData : SensorData,IBusinessEquatable
    {
        public virtual string SSID { get; set; }

        public virtual IList<MacAddress> BSSIDs { get; set; }

        public virtual double SignalStrength { get; set; }

        #region Overrides of SensorData

        public override double SquaredDistanceFrom(SensorData other)
        {
            throw new NotImplementedException();
        }

        #endregion

        public bool BusinessEquals(WlanSensorData other, bool compareSignalStrength)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return SSID.Equals(other.SSID) &&
                   BSSIDs.SequenceEqual(other.BSSIDs) &&
                   (!compareSignalStrength || SignalStrength.Equals(other.SignalStrength));
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
            return BusinessEquals(obj as WlanSensorData,true);
        }
    }
}