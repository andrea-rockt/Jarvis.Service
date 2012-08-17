using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Business.Statistics;
using Jarvis.Service.Domain.Repos;
using Jarvis.Service.Domain.Statistics;
using Loc = Jarvis.Service.Domain.Location;
using Moq;
using NUnit.Framework;

namespace Jarvis.Service.Test.Business.Statistics
{
    [TestFixture]
    public class StatsCollectorTest
    {
        private StatsCollector _sut;
        const int DistinctLocations = 20;
        private List<LocationStats> _fakeRepoList = new List<LocationStats>();
        private Queue<Loc.Location> _locations = new Queue<Service.Domain.Location.Location>();

        [SetUp]
        public void SetUp()
        {
            _locations.Clear();

            foreach (var mockLocation in MockLocations(DistinctLocations))
            {
                _locations.Enqueue(mockLocation);        
            }
            
            var mockLocationProvider = new Mock<ILocationProvider>();
            mockLocationProvider.Setup(x => x.ComputedLocation).Returns(() =>
                                                                            {
                                                                                var loc = _locations.Dequeue();
                                                                                _locations.Enqueue(loc);
                                                                                return loc;
                                                                            });

            var mockRepo = new Mock<ILocationStatsRepository>();
            mockRepo.Setup(x => x.Add(It.IsAny<IEnumerable<LocationStats>>())).Returns(true).Callback
                <IEnumerable<LocationStats>>(range => _fakeRepoList.AddRange(range));
            mockRepo.Setup(x => x.Add(It.IsAny<LocationStats>())).Returns(true).Callback
                <LocationStats>(location => _fakeRepoList.Add(location));
            mockRepo.Setup(x => x.All()).Returns(_fakeRepoList.AsQueryable);

            _sut = new StatsCollector(mockRepo.Object,mockLocationProvider.Object,TimeSpan.FromMinutes(1));
        }

        [Test]
        public void CollectTest()
        {
            DateTime now = DateTime.Now;

            for(int i=0 ; i<2001;i++)
            {
                _sut.Collect(now);
                now = now.AddHours(1);
            }

            var locationsStats = _sut.GetAllStats();

            Assert.That(locationsStats.Count,Is.EqualTo(DistinctLocations));

            foreach (var locationStats in locationsStats)
            {
                Assert.That(locationStats.Entries.Count, Is.EqualTo(200).Or.EqualTo(201),"Location guid : {0}",locationStats.Location.Id);
            }
        }

        private IEnumerable<Loc.Location> MockLocations(byte howMuch)
        {
            Guid startingGuid = Guid.Parse("3ebea10b-5846-4aac-9ad7-7ad03f7d8b1b");
            var guidBytes = startingGuid.ToByteArray();

            byte counter = 0;
            while(counter++ < howMuch)
            {
                var mockLocation = new Mock<Loc.Location>();
                guidBytes[15] = counter;
                mockLocation.Setup(x => x.Id).Returns(new Guid(guidBytes));
                yield return mockLocation.Object;
            }
        }
    }
}
