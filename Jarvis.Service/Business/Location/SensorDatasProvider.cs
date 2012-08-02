using Jarvis.Service.Domain.Location;
using ManagedWifi;

namespace Jarvis.Service.Business.Location
{
    public class SensorDatasProvider : ISensorDatasProvider
    {
        private readonly IManagedWifiContext _managedWifiContext;
        
        public SensorDatasProvider(IManagedWifiContext managedWifiContext)
        {
            _managedWifiContext = managedWifiContext;
        }

        public LocationSensorDatas GetCurrentSensorDatas()
        {
            throw new System.NotImplementedException();
        }
    }
}