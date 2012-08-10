using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jarvis.Service.Domain.Mappings;
using Jarvis.Service.Domain.Repos;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Repos
{
    [TestFixture]
    public class LocationStatsNhRepositoryTest : NhRepositoryTestBase
    {
        [Test]
        public void SaveTest()
        {
            var locationStats = XamlServices.Load(@"Domain\Repos\LocationStatsData.xaml") as List<Jarvis.Service.Domain.Statistics.LocationStats>;
            ILocationStatsRepository repository = new LocationStatsNhRepository(Session);

            Assert.DoesNotThrow(() => repository.Add(locationStats));
        }
    }
}
