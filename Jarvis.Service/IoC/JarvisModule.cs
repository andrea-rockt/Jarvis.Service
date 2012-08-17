using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Business.Location;
using Jarvis.Service.Business.Statistics;
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
            Bind<IManagedWifiContext>().To<ManagedWifiContext>().WithConstructorArgument("requiredClientVersion",
                                                                                         ManagedWifiContext.NWlanVersion
                                                                                             .WindowsXP);
            Bind<ILocationProvider>().To<LocationProvider>();
            Bind<ISensorDatasProvider>().To<WlanSensorDatasProvider>();
            Bind<IStatsCollector>().To<StatsCollector>().WithConstructorArgument("collectionPeriod",Properties.Settings.Default.CollectionPeriod);
            Bind<JarvisServiceHost>().ToSelf();
        }

        #endregion
    }
}
