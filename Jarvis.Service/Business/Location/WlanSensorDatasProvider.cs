using System.Collections.Generic;
using System.Linq;
using Jarvis.Service.Domain.Location;
using ManagedWifi;

namespace Jarvis.Service.Business.Location
{
    public class WlanSensorDatasProvider : ISensorDatasProvider
    {
        private readonly IManagedWifiContext _managedWifiContext;

        public WlanSensorDatasProvider(IManagedWifiContext managedWifiContext)
        {
            _managedWifiContext = managedWifiContext;
        }

        public LocationSensorDatas GetCurrentSensorDatas()
        {
            var sensorDatas = from i in _managedWifiContext.Interfaces
                    from n in _managedWifiContext.GetAvailableNetworks(i)
                    select new WlanSensorData()
                               {
                                   SignalStrength = ((double) n.SignalStrength)/100d,
                                   SSID = n.SSID,
                                   BSSIDs =
                                       (from physicalAddress in n.BSSIDs
                                        select MacAddress.FromPhysicalAddress(physicalAddress)).ToList()
                               };


            return new LocationSensorDatas() {SensorDatas = sensorDatas.Cast<SensorData>().ToList()};
        }
    }
}