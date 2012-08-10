using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Jarvis.Service.Domain.Mappings
{
    public class LocationStatsMap : ClassMap<Statistics.LocationStats>
    {
        public LocationStatsMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            HasOne(x => x.Location).Cascade.All();
            HasMany(x => x.Entries).Cascade.All();
        }
    }
}
