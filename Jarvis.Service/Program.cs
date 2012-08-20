using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using Jarvis.Service.IoC;
using Ninject;
using Ninject.Modules;

namespace Jarvis.Service
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        static void Main()
        {

            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var modules = new INinjectModule[]
                                           {
                                               new JarvisModule(), 
                                               new NHibernateModule(), 
                                               new WcfModule(),
                                               new AutoMapperModule(), 
                                           };

            IKernel kernel = new StandardKernel(modules);

            ServiceBase jarvisService = kernel.Get<JarvisServiceHost>();


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				jarvisService
			};
            ServiceBase.Run(ServicesToRun);

//            ((JarvisServiceHost)jarvisService).DebugOnStart(new string[]{});


        }
    }
}
