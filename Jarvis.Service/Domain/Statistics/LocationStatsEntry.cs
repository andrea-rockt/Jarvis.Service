using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Statistics
{
    public class LocationStatsEntry : Entity<Guid>
    {

        public enum EntryKind
        {
            Exit,
            Enter
        }

        public virtual DateTime Date { get; set; }
        public virtual EntryKind Kind { get; set; }
    }

    
}
