using System;
using System.Collections.Generic;

namespace Jarvis.Service.Domain.Location
{
    public class WlanSensorData : SensorData
    {
        public virtual string SSID { get;  set; }

        public virtual IList<MacAddress> BSSIDs { get;  set; }

        public virtual double SignalStrength { get;  set; }

        #region Overrides of SensorData

        public override double SquaredDistanceFrom(SensorData other)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
