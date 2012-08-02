using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Jarvis.Service.Extensions;
using ManagedWifi;
using Moq;
using NHibernate.Linq;
using NUnit.Framework;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;

namespace Jarvis.Service.Test.Business.Location
{
    [TestFixture]
    public class SensorDatasProviderTest
    {
        private MoqMockingKernel _kernel;

        [TestFixtureSetUp]
        public void SetupFixture()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<IManagedWifiContext>().ToMock();
        }

        [Test]
        public void ShouldReturnCorrectLocationSensorDatas()
        {

            var networks = from i in Enumerable.Range(0, 10)
            select NewMockedNetwork();
            
            networks.ForEach((x)=>Console.WriteLine(x.SSID));
             
        }

        private byte _mockCounter = 1;
        private INetwork NewMockedNetwork()
        {
            var mockNetwork = new Mock<INetwork>();

            mockNetwork.Setup(m => m.SSID).Returns("Rete " + _mockCounter);
            mockNetwork.Setup(m => m.BSSIDs).Returns(
                () => new[] {new PhysicalAddress(new byte[] {0xFA, 0xCE, 0xDE, 0xAD, 0xAC, _mockCounter})});
            mockNetwork.Setup(m => m.Type).Returns(BSSType.Infrastructure);
            mockNetwork.Setup(m => m.SignalStrength).Returns(100);

            _mockCounter++;
            return mockNetwork.Object;
        }
    }
}
