using System;
using System.Collections.Generic;

namespace Jarvis.Service.Domain.Location
{
    public class WlanSensorData : SensorData
    {
        public virtual string SSID { get; protected set; }

        public virtual IList<MacAddress> BSSIDs { get; protected set; }

        public virtual double SignalStrength { get; protected set; }

        #region Overrides of SensorData

        public override double SquaredDistanceFrom(SensorData other)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
