using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Statistics;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Statistics
{
    [TestFixture]
    public class LocationStatsTest
    {
        [Test]
        public void ShouldReturnCorrectSpentTime()
        {

            var enterDateTime = DateTime.Now;
            var exitDateTime = enterDateTime.AddDays(1);

            var resultTimeSpan= exitDateTime.Subtract(enterDateTime);

            var stat = new LocationStats
                           {
                               Entries = new List<LocationStatsEntry>
                                             {
                                                 new LocationStatsEntry
                                                     {
                                                         Date = enterDateTime,
                                                         Kind = LocationStatsEntry.EntryKind.Enter
                                                     },
                                                 new LocationStatsEntry
                                                     {
                                                         Date = exitDateTime,
                                                         Kind = LocationStatsEntry.EntryKind.Exit
                                                     }
                                             }
                           };

            Assert.AreEqual(resultTimeSpan,stat.GetTotalTimeSpent());

        }

        [Test]
        public void ShouldThrowExceptionForMalformedData()
        {

            var enterDateTime = DateTime.Now;
            var exitDateTime = enterDateTime.AddDays(1);

            var resultTimeSpan = exitDateTime.Subtract(enterDateTime);

            var stat = new LocationStats
            {
                Entries = new List<LocationStatsEntry>
                                             {
                                                 new LocationStatsEntry
                                                     {
                                                         Date = enterDateTime,
                                                         Kind = LocationStatsEntry.EntryKind.Exit
                                                     },
                                                     new LocationStatsEntry
                                                     {
                                                         Date = exitDateTime,
                                                         Kind = LocationStatsEntry.EntryKind.Enter
                                                     }
                                             }
            };

            Assert.That(() => stat.GetTotalTimeSpent(), Throws.Exception.TypeOf<InvalidOperationException>());
            

        }

        [Test]
        public void ShouldReturnZeroTimespanForNoEntry()
        {
            var stat = new LocationStats
                           {
                               Entries = new List<LocationStatsEntry>()
                           };

            Assert.That(()=>stat.GetTotalTimeSpent(),Is.EqualTo(TimeSpan.Zero));
        }
    }
}
