using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Domain.Mappings
{
    public class SensorDataMap : ClassMap<SensorData>
    {
        public SensorDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
        }
    }
}
