using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Domain.Mappings
{
    public class LocationSensorDatasMap :ClassMap<LocationSensorDatas>
    {
        public LocationSensorDatasMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasMany(x => x.SensorDatas).Cascade.All();
        }
    }
}
