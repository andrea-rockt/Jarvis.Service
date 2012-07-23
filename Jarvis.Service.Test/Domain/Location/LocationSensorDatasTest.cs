using System.Collections.Generic;
using Jarvis.Service.Domain.Location;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Location
{
    [TestFixture]
    public class LocationSensorDatasTest
    {
        [Test]
        public void Equivalence()
        {
            var sensor1 = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var sensor2 = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xAA } } },
                SignalStrength = 0.1,
                SSID = "Rete1"
            };


            var left = new LocationSensorDatas() {SensorDatas = new List<SensorData>() {sensor1, sensor2}};
            var right = new LocationSensorDatas() { SensorDatas = new List<SensorData>() { sensor1, sensor2 } };

            Assert.IsTrue(left.BusinessEquals(right));
            Assert.IsTrue(right.BusinessEquals(left));
            Assert.IsTrue(right.Equals(left));
        }

        [Test]
        public void Inequivalence()
        {
            var sensor1 = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var sensor2 = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xAA } } },
                SignalStrength = 0.1,
                SSID = "Rete1"
            };
            var sensor3 = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xAA } } },
                SignalStrength =4,
                SSID = "Rete1"
            };


            var left = new LocationSensorDatas() { SensorDatas = new List<SensorData>() { sensor1, sensor2 } };
            var right = new LocationSensorDatas() { SensorDatas = new List<SensorData>() { sensor1, sensor3 } };

            Assert.IsFalse(left.BusinessEquals(right));
            Assert.IsFalse(right.BusinessEquals(left));
            Assert.IsFalse(right.Equals(left));
        }
    }
}
