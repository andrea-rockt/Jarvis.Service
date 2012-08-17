using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Jarvis.Service
{
    public partial class JarvisService : ServiceBase
    {
        public JarvisService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

#if DEBUG
        public void DebugOnStart(string[] args)
        {
            OnStart(args);
        }
#endif
    }
}
