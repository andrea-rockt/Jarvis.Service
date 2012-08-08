using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Domain.Location;
using ManagedWifi;
using Moq;
using NHibernate.Linq;
using NUnit.Framework;

namespace Jarvis.Service.Test.Business.Location
{
    [TestFixture]
    public class WlanSensorDatasProviderTest
    {
        private WlanSensorDatasProvider _sut;

        [SetUp]
        public void Setup()
        {
            var m = new Mock<IManagedWifiContext>();
            m.Setup(x => x.Interfaces).Returns(MockedInterfaces(1));
            m.Setup(x => x.GetAvailableNetworks(It.IsAny<IInterface>())).Returns(MockedNetworks(10));
            _sut = new WlanSensorDatasProvider(m.Object);
        }

        [Test]
        public void ShouldReturnCorrectLocationSensorDatas()
        {
            Assert.True(MockedNetworks(10).All((x) => _sut.GetCurrentSensorDatas().SensorDatas.Any(y => y.As<WlanSensorData>().SSID.Equals(x.SSID))));
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
        private IEnumerable<INetwork> MockedNetworks(int howMuch)
        {
            int mockCounter = 1;
            while (mockCounter<=howMuch)
            {

                var mockNetwork = new Mock<INetwork>();
                mockNetwork.Setup(m => m.SSID).Returns("Rete " + mockCounter);
                byte[] bytes = BitConverter.GetBytes(mockCounter);
                mockNetwork.Setup(m => m.BSSIDs).Returns(
                    () => new[] { new PhysicalAddress(new byte[] { 0xFA, 0xCE, bytes[3], bytes[2], bytes[1], bytes[0] }) });
                mockNetwork.Setup(m => m.Type).Returns(BSSType.Infrastructure);
                mockNetwork.Setup(m => m.SignalStrength).Returns(100);

                mockCounter++;
                yield return mockNetwork.Object;
            }
        }
    }
}
