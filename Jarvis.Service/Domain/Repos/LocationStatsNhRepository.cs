using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Jarvis.Service.Domain.Repos
{
    public class LocationStatsNhRepository : DomainModel.NhRepository<Statistics.LocationStats, Guid>, ILocationStatsRepository
    {
        public LocationStatsNhRepository(ISession session) : base(session)
        {
        }
    }
}
