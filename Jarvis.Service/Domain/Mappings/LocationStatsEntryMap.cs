using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Jarvis.Service.Domain.Mappings
{
    public class LocationStatsEntryMap :ClassMap<Statistics.LocationStatsEntry>
    {
        public LocationStatsEntryMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Kind).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
        }
    }
}
