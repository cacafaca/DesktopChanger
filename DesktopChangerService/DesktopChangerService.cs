using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChangerService
{
    public partial class DesktopChangerService : ServiceBase
    {
        public DesktopChangerService()
        {
            InitializeComponent();
            messageListener = new MessageListener();
        }

        MessageListener messageListener;

        protected override void OnStart(string[] args)
        {
            messageListener.Start();
        }

        protected override void OnStop()
        {
            messageListener.Stop();
        }

    }
}
