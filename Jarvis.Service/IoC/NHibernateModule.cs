using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Jarvis.Service.Domain.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;
using Ninject.Modules;
using Ninject;
namespace Jarvis.Service.IoC
{
    public class NHibernateModule:NinjectModule
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Bind<ISessionFactory>().ToMethod(CreateSessionFactory).InSingletonScope();
            Bind<ISession>().ToMethod((x) => x.Kernel.Get<ISessionFactory>().OpenSession()).InThreadScope();
        }

        #endregion

        private static ISessionFactory CreateSessionFactory(IContext ctx)
        {            
              var  sessionFactory = Fluently
                .Configure()
                .Database(
                SQLiteConfiguration.Standard.UsingFile(Properties.Settings.Default.DbPath)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LocationMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            return sessionFactory;
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(false, true);
        }
    }
}
