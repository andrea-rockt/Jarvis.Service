using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jarvis.Service.Domain.Action;
using Jarvis.Service.Domain.Location;
using Jarvis.Service.Domain.Mappings;
using Jarvis.Service.Domain.Repos;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Action = Jarvis.Service.Domain.Action.Action;

namespace Jarvis.Service.Test.Domain.Repos
{
    [TestFixture]
    public class LocationNhRepositoryTest : NhRepositoryTestBase
    {
        [Test]
        public void SaveTest()
        {
            var locations = XamlServices.Load(@"Domain\Repos\Data.xaml") as List<Jarvis.Service.Domain.Location.Location>;
            ILocationRepository repository = new LocationNhRepository(Session);
            Assert.DoesNotThrow(()=>repository.Add(locations));

            repository.All().ForEach(l => l.LocationSensorDatas.SensorDatas.ForEach(d => Console.WriteLine(d.Id)));
        }
    }
}
