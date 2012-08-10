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
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Action = Jarvis.Service.Domain.Action.Action;

namespace Jarvis.Service.Test.Domain.Repos
{
    [TestFixture]
    public class LocationNhRepositoryTest
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;

        
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            File.Delete("jarvis_test.sqlite3");
            _sessionFactory = Fluently
                .Configure()
                .Database(
                SQLiteConfiguration.Standard.UsingFile("jarvis_test.sqlite3")
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LocationMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            _session.Flush();
            _session.Close();
            _session.Dispose();
            _sessionFactory.Close();
            _sessionFactory.Dispose();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }

        [Test]
        public void SaveTest()
        {
            var locations = XamlServices.Load(@"Domain\Repos\Data.xaml") as List<Jarvis.Service.Domain.Location.Location>;
            ILocationRepository repository = new LocationNhRepository(_session);

            repository.Add(locations);
        }
    }
}
