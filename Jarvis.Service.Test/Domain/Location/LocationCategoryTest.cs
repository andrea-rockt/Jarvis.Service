using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Location;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Location
{
    [TestFixture]
    public class LocationCategoryTest
    {
        [Test]
        public void Equivalence()
        {
            var left = new LocationCategory() {Name = "Categoria1"};
            var right = new LocationCategory() { Name = "Categoria1" };

            Assert.IsTrue(left.BusinessEquals(right));
            Assert.IsTrue(right.BusinessEquals(left));
            Assert.IsTrue(left.Equals(right));
        }

        [Test]
        public void Inequivalence()
        {
            var left = new LocationCategory() { Name = "Categoria1" };
            var right = new LocationCategory() { Name = "Categoria2" };

            Assert.IsFalse(left.BusinessEquals(right));
            Assert.IsFalse(right.BusinessEquals(left));
            Assert.IsFalse(left.Equals(right));
        }
    }
}
