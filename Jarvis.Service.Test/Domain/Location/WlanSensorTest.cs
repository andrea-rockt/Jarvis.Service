using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Location;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Location
{
    [TestFixture]
    public class WlanSensorTest
    {
        [Test]
        public void EquivalenceWithSignal()
        {
            var left = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>(){new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } }},
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var right = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>(){new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } }},
                SignalStrength = 1,
                SSID = "Rete1"
            };

            Assert.IsTrue(left.BusinessEquals(right,true));
            Assert.IsTrue(right.BusinessEquals(left,true));
            Assert.IsTrue(right.Equals(left));
        }
        [Test]
        public void EquivalenceWithoutSignal()
        {
            var left = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var right = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 0.5,
                SSID = "Rete1"
            };

            Assert.IsTrue(left.BusinessEquals(right,false));
            Assert.IsTrue(right.BusinessEquals(left,false));
        }

        [Test]
        public void InequivalenceWithoutSignal()
        {
            var left = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var right = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xAA } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };

            Assert.IsFalse(left.BusinessEquals(right, false));
            Assert.IsFalse(right.BusinessEquals(left, false));
        }
        [Test]
        public void Inequivalence()
        {
            var left = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 1,
                SSID = "Rete1"
            };
            var right = new WlanSensorData()
            {
                BSSIDs = new List<MacAddress>() { new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } } },
                SignalStrength = 0.1,
                SSID = "Rete1"
            };
            
            Assert.IsFalse(left.BusinessEquals(right,true));
            Assert.IsFalse(right.BusinessEquals(left,true));
            Assert.IsFalse(right.Equals(left));
        }

    }
}
