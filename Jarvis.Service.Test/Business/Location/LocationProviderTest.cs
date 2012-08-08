using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Domain.Location;
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

        [SetUp]
        public void SetUp()
        {

            int callNumber = 0;
            var m = new Mock<IManagedWifiContext>();
            m.Setup(x => x.Interfaces).Returns(MockedInterfaces(1));
            m.Setup(x => x.GetAvailableNetworks(It.IsAny<IInterface>())).Returns(() => MockedNetworks(10, callNumber)).Callback(() => callNumber = (callNumber + 1) % DistinctLocations);
            _sut = new LocationProvider(new WlanSensorDatasProvider(m.Object));    
        }

        [Test]
        public void DependencyShouldBeProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new LocationProvider(null));
        }

        [Test]
        public void ShouldReturnCorrectCurrentLocation()
        {
            for (int i = 0; i < DistinctLocations; i++ ){
                Assert.True(MockedNetworks(10,i).All((x) => _sut.CurrentLocation.LocationSensorDatas.SensorDatas.Any(y => y.As<WlanSensorData>().SSID.Equals(x.SSID))));
            }
        }

        [Test]
        public void ShouldReturnCorrectComputedLocation()
        {

            IList<Service.Domain.Location.Location> locations = new List<Service.Domain.Location.Location>();
            for (int i = 0; i < DistinctLocations; i++)
            {
                var current = _sut.CurrentLocation;
                locations.Add(current);
                _sut.StoreAsKnownLocation(current);
            }

            Assert.True(locations[0].LocationSensorDatas.BusinessEquals(_sut.ComputedLocation.LocationSensorDatas));
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
