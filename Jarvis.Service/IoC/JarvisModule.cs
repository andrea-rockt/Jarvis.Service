using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Business.Statistics;
using Jarvis.Service.Domain.Repos;
using ManagedWifi;
using Ninject.Modules;

namespace Jarvis.Service.IoC
{
    class JarvisModule : NinjectModule
    {
        #region Overrides of NinjectModule

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IManagedWifiContext>().To<ManagedWifiContext>();
            Bind<ILocationProvider>().To<LocationProvider>();
            Bind<ISensorDatasProvider>().To<WlanSensorDatasProvider>();
            Bind<ILocationRepository>().To<LocationNhRepository>();
            Bind<ILocationStatsRepository>().To<LocationStatsNhRepository>();
            Bind<IStatsCollector>().To<StatsCollector>();
        }

        #endregion
    }
}
