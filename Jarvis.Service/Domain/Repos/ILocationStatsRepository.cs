using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Repos
{
    public interface ILocationStatsRepository : IRepository<Statistics.LocationStats,Guid>
    {
    }
}
