﻿using FluentNHibernate.Mapping;

namespace Jarvis.Service.Domain.Mappings
{
    public class LocationMap : ClassMap<Location.Location>
    {
        public LocationMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name).Not.Nullable().Unique();
            Map(x => x.State);
            Map(x => x.StreetAddress);
            Map(x => x.City);
            HasMany(x => x.Categories).Cascade.All();
            HasMany(x => x.Actions).Cascade.All();
            References(x => x.LocationSensorDatas).Cascade.All();
        }
    }
}
