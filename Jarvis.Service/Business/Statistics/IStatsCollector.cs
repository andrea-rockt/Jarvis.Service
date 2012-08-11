using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Statistics;

namespace Jarvis.Service.Business.Statistics
{
    public interface IStatsCollector
    {
        IList<LocationStats> GetAllStats();
        LocationStats StatsForLocation(Domain.Location.Location location);

        bool IsCollecting { get;  }
        void StartCollecting();
        void StopCollecting();

    }
}
