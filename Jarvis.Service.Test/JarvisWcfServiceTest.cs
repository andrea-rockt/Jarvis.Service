using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;
using AutoMapper;
using Jarvis.Service.IoC;
using NUnit.Framework;
using Ninject;
using Ninject.Modules;

namespace Jarvis.Service.Test
{
    [TestFixture]
    public class JarvisWcfServiceTest
    {
        private JarvisWcfService _sut;
        private IMappingEngine _mappingEngine;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            File.Delete("jarvis.sqlite3");
            var modules = new INinjectModule[]
                              {
                                  new NHibernateModule(),
                                  new JarvisModule(),
                                  new AutoMapperModule(),
                                  new WcfModule(),
                              };
            var kernel = new StandardKernel(modules);

            _sut = kernel.Get<JarvisWcfService>();
            _mappingEngine = kernel.Get<IMappingEngine>();

            
        }

        [Test]
        public void Test1()
        {

            var locations = XamlServices.Load("Locations.xaml") as IList<Jarvis.Service.Domain.Location.Location>;

            foreach (var location in locations)
            {
                _sut.StoreCurrentLocation(_mappingEngine.Map<Jarvis.WCF.Contracts.Data.Location>(location));
            }

            foreach (var knownLocation in _sut.GetKnownLocations())
            {
                Console.WriteLine(knownLocation.Name);
            }

            Console.WriteLine("Winner");
            Console.WriteLine(_sut.GetCurrentLocation().Name);

            
        }
    }
}
