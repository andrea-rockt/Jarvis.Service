using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Xaml;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jarvis.Service.Domain.Location;
using Jarvis.Service.Domain.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Repos
{
    [TestFixture]
    public class LocationNhRepositoryTest
    {
        private ISession _session;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var sessionFactory = Fluently
                .Configure()
                .Database(
                SQLiteConfiguration.Standard.UsingFile("jarvis_test.sqlite3")
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LocationMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            _session = sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }

        [Test]
        public void SaveTest()
        {
            var locations = XamlServices.Load(@"Domain\Repos\Data.xaml") as List<Jarvis.Service.Domain.Location.Location>;
        }
    }
}
