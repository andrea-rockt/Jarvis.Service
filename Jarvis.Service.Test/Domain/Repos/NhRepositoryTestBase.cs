using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jarvis.Service.Domain.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Jarvis.Service.Test.Domain.Repos
{
    public class NhRepositoryTestBase
    {
        protected ISessionFactory SessionFactory;
        protected ISession Session;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            File.Delete("jarvis_test.sqlite3");
            SessionFactory = Fluently
                .Configure()
                .Database(
                    SQLiteConfiguration.Standard.UsingFile("jarvis_test.sqlite3")
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LocationMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            Session = SessionFactory.OpenSession();
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            Session.Flush();
            Session.Close();
            Session.Dispose();
            SessionFactory.Close();
            SessionFactory.Dispose();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}