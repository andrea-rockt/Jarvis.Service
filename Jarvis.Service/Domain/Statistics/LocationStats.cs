using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Statistics
{
    public class LocationStats :Entity<Guid>
    {
        public virtual Location.Location Location { get; set; }
        public virtual IList<LocationStatsEntry> Entries { get; set; }

        public double TotalTimeSpent { get { throw new NotImplementedException(); } }
    }
}
