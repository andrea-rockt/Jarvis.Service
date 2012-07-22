using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Location;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Location
{
    [TestFixture]
    public class MacAddressTest
    {
        [Test]
        public void Equivalence()
        {
            var left = new MacAddress() {Bytes = new byte[] {0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF}};
            var right = new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } };

            Assert.IsTrue(left.IsEquivalent(right));
            Assert.IsTrue(right.IsEquivalent(left));
            Assert.IsTrue(right.Equals(left));
        }

        [Test]
        public void Inequivalence()
        {
            var left = new MacAddress() { Bytes = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } };
            var right = new MacAddress() { Bytes = new byte[] { 0xCC, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF } };

            Assert.IsFalse(left.IsEquivalent(right));
            Assert.IsFalse(right.IsEquivalent(left));
            Assert.IsFalse(right.Equals(left));
        }
    }
}
