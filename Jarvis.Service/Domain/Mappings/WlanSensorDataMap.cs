using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Domain.Mappings
{
    public class WlanSensorDataMap : SubclassMap<WlanSensorData>
    {
        public WlanSensorDataMap()
        {
            Map(x => x.SignalStrength).Not.Nullable();
            Map(x => x.SSID).Not.Nullable();
            HasMany(x => x.BSSIDs).Cascade.All();
        }
    }
}
