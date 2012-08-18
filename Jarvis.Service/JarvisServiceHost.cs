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

namespace Jarvis.Service
{
    public partial class JarvisServiceHost : ServiceBase
    {
        private ServiceHost _serviceHost;
        public JarvisServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var baseAddress = new Uri(Properties.Settings.Default.ServiceUri);

            _serviceHost = new ServiceHost(typeof(WCFService), baseAddress);

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
