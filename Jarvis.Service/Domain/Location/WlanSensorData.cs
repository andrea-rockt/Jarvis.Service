using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Location
{
    public class WlanSensorData : SensorData
    {
        public virtual string SSID { get; set; }

        public virtual IList<MacAddress> BSSIDs { get; set; }

        public virtual double SignalStrength { get; set; }

        #region Overrides of SensorData

        public override double SquaredDistanceFrom(SensorData other)
        {
            other.GetType();
            var otherSensor = other as WlanSensorData;

            if (!BusinessEquals(otherSensor, false))
                return 1d;

            Debug.Assert(otherSensor != null, "otherSensor != null");
            return Math.Pow(SignalStrength - otherSensor.SignalStrength, 2);
        }

        #endregion

        public virtual bool BusinessEquals(WlanSensorData other, bool compareSignalStrength)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return SSID.Equals(other.SSID) &&
                   BSSIDs.All((x)=> other.BSSIDs.Any(y=> x.BusinessEquals(y))) &&
                   (!compareSignalStrength || SignalStrength.Equals(other.SignalStrength));
        }


        /// <summary>
        /// Checks Businness rule equivalence
        /// </summary>
        /// <param name="obj">Object to check for equivalence</param>
        /// <returns></returns>
        public override  bool BusinessEquals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return BusinessEquals(obj as WlanSensorData,true);
        }
    }
}