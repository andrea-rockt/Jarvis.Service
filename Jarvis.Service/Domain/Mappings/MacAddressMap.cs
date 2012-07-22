using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Domain.Mappings
{
    public class MacAddressMap:ClassMap<MacAddress>
    {
        public MacAddressMap()
        {
            Id(x => x.Id);
            Map(x => x.Bytes).Not.Nullable();
        }
    }
}
