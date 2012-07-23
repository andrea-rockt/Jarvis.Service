using FluentNHibernate.Mapping;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Domain.Mappings
{
    public class LocationCategoryMap : ClassMap<LocationCategory>
    {
        public LocationCategoryMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name).Not.Nullable().Unique();
        }
    }
}
