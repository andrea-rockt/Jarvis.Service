using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xaml;
using Jarvis.Service.Domain.Location;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Repos
{
    [TestFixture]
    public class LocationNhRepositoryTest
    {
        [Test]
        public void SaveTest()
        {
            var locations = XamlServices.Load(@"Domain\Repos\Data.xaml") as List<Jarvis.Service.Domain.Location.Location>;
        }
    }
}
