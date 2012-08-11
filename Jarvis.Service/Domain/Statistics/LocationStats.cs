using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Statistics
{
    public class LocationStats : Entity<Guid>
    {
        public virtual Location.Location Location { get; set; }
        public virtual IList<LocationStatsEntry> Entries { get; set; }

        public virtual TimeSpan GetTotalTimeSpent()
        {
            var enterEntries = from entry in Entries
                               where entry.Kind.Equals(LocationStatsEntry.EntryKind.Enter)
                               orderby entry.Date ascending
                               select entry;
            var exitEntries = from entry in Entries
                              where entry.Kind.Equals(LocationStatsEntry.EntryKind.Exit)
                              orderby entry.Date ascending
                              select entry;

            if (!enterEntries.Any() || !exitEntries.Any())
            {
                return TimeSpan.Zero;
            }

            var resultTimespan =
                enterEntries.Zip(exitEntries, 
                    (enter, exit) =>{
                                        if (enter.Date.CompareTo(exit.Date) > 0)
                                            throw new InvalidOperationException(
                                                "Location Statistics data is inconsistent");
                                        return exit.Date.Subtract(enter.Date);
                                    }).Aggregate((x, acc) => acc.Add(x));

            return resultTimespan;
        }
    }
}
