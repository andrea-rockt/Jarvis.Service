using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;

namespace Jarvis.Service.IoC
{
    public class WcfModule : NinjectModule
    {
        #region Overrides of NinjectModule

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            //Bind<IJarvisWcfService>().To<JarvisWcfService>().InSingletonScope();
        }

        #endregion
    }
}
