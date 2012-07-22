using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        #endregion

        public bool IsEquivalent(WlanSensorData other, bool compareSignalStrength)
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
        /// <param name="other">Object to check for equivalence</param>
        /// <returns></returns>
        public override bool IsEquivalent(Entity<Guid> obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return IsEquivalent(obj as WlanSensorData, true);
        }
    }
}