using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Jarvis.Service
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        static void Main()
        {
#if ! DEBUG
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new Service1() 
			};
            ServiceBase.Run(ServicesToRun);
#else
            (new JarvisService()).DebugOnStart(new string[]{});
#endif

        }
    }
}
