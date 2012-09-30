using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using Jarvis.WCF.Contracts.Service;

namespace Jarvis.Service
{
    public partial class JarvisServiceHost : ServiceBase
    {
        private ServiceHost _serviceHost;

        private readonly JarvisWcfService _singletonService;


        public JarvisServiceHost(JarvisWcfService singletonService)
        {
            this._singletonService = singletonService;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var baseAddresses = new Uri[]
                                    {
                                        new Uri(Properties.Settings.Default.ServiceHttpUri),
                                        new Uri(Properties.Settings.Default.ServiceNamedPipeUri),
                                    };

            _serviceHost = new ServiceHost(_singletonService, baseAddresses);

            _serviceHost.AddServiceEndpoint(typeof(ILocationService),
            new BasicHttpBinding(),
            "Location");

            _serviceHost.AddServiceEndpoint(typeof(ILocationService),
              new NetNamedPipeBinding(),
              "Location");

            
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            _serviceHost.Description.Behaviors.Add(smb);

            _serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            _serviceHost.Close();
        }

#if DEBUG
        public void DebugOnStart(string[] args)
        {
            OnStart(args);
        }
#endif
    }
}
