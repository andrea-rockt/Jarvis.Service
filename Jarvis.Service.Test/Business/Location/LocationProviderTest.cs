using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Domain.Location;
using Jarvis.Service.Domain.Repos;
using ManagedWifi;
using Moq;
using NHibernate.Linq;
using NUnit.Framework;

namespace Jarvis.Service.Test.Business.Location
{
    [TestFixture]
    public class LocationProviderTest
    {
        private LocationProvider _sut;
        const int DistinctLocations = 3;
        private List<Service.Domain.Location.Location> _fakeRepoList = new List<Service.Domain.Location.Location>();

        [SetUp]
        public void SetUp()
        {
            _fakeRepoList.Clear();
            int callNumber = 0;
            var mockContext = new Mock<IManagedWifiContext>();
            mockContext.Setup(x => x.Interfaces).Returns(MockedInterfaces(1));
            mockContext.Setup(x => x.GetAvailableNetworks(It.IsAny<IInterface>())).Returns(() => MockedNetworks(10, callNumber)).Callback(() => callNumber = (callNumber + 1) % DistinctLocations);

            var mockRepo = new Mock<ILocationRepository>();
            mockRepo.Setup(x => x.Add(It.IsAny<IEnumerable<Service.Domain.Location.Location>>())).Returns(true).Callback
                <IEnumerable<Service.Domain.Location.Location>>(range => _fakeRepoList.AddRange(range));
            mockRepo.Setup(x => x.Add(It.IsAny<Service.Domain.Location.Location>())).Returns(true).Callback
                <Service.Domain.Location.Location>(location => _fakeRepoList.Add(location));
            mockRepo.Setup(x => x.All()).Returns(_fakeRepoList.AsQueryable);

            _sut = new LocationProvider(new WlanSensorDatasProvider(mockContext.Object),mockRepo.Object);    
        }

        [Test]
        public void DependencyShouldBeProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new LocationProvider(new WlanSensorDatasProvider((new Mock<IManagedWifiContext>()).Object),null));
            Assert.Throws<ArgumentNullException>(() => new LocationProvider(null, (new Mock<ILocationRepository>()).Object));
            Assert.Throws<ArgumentNullException>(() => new LocationProvider(null, null));
        }

        [Test]
        public void ShouldReturnCorrectCurrentLocation()
        {
            for (int i = 0; i < DistinctLocations; i++ ){
                var mockedNetworks = MockedNetworks(10, i).ToList();
                var currentLocation = _sut.CurrentLocation;

                for(int j=0; j<mockedNetworks.Count;j++)
                {
                    Assert.IsTrue(currentLocation.LocationSensorDatas.SensorDatas[j].As<WlanSensorData>().SSID.Equals(mockedNetworks[j].SSID));
                }
                
            }
        }

        [Test]
        public void ShouldReturnCorrectComputedLocation()
        {

            IList<Service.Domain.Location.Location> locations = new List<Service.Domain.Location.Location>();
            for (int i = 0; i < DistinctLocations; i++)
            {
                var current = new Service.Domain.Location.Location();
                locations.Add(current);
                _sut.StoreAsKnownLocation(current);
            }

            Assert.True(locations[0].LocationSensorDatas.BusinessEquals(_sut.ComputedLocation.LocationSensorDatas));
            _fakeRepoList.Clear();
            Assert.IsNull(_sut.ComputedLocation);
        }

        private IEnumerable<IInterface> MockedInterfaces(int howMuch)
        {
            int mockCounter = 1;
            while (mockCounter <= howMuch)
            {
                var i = new Mock<IInterface>();
                i.Setup(x => x.Description).Returns("Interface " + mockCounter);
                mockCounter++;

                yield return i.Object;
            }
        }
        private IEnumerable<INetwork> MockedNetworks(int howMuch, int setNumber)
        {
            int mockCounter = 1;
            while (mockCounter <= howMuch)
            {

                var mockNetwork = new Mock<INetwork>();
                mockNetwork.Setup(m => m.SSID).Returns(String.Format("Rete {0} - Set {1}",mockCounter,setNumber));
                byte[] mockCounterBytes = BitConverter.GetBytes(mockCounter);
                byte[] setNumberBytes = BitConverter.GetBytes(setNumber);
                mockNetwork.Setup(m => m.BSSIDs).Returns(
                    () => new[] { new PhysicalAddress(new byte[] { setNumberBytes[1], setNumberBytes[0], mockCounterBytes[3], mockCounterBytes[2], mockCounterBytes[1], mockCounterBytes[0] }) });
                mockNetwork.Setup(m => m.Type).Returns(BSSType.Infrastructure);
                mockNetwork.Setup(m => m.SignalStrength).Returns(100);

                mockCounter++;
                yield return mockNetwork.Object;
            }
        }
    }
}
