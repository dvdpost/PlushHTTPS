using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;


namespace PlushHTTPS
{
    [RunInstaller(true)]
    public partial class PlushHttpsServiceInstaller : Installer
    {
        public PlushHttpsServiceInstaller()
        {
            InitializeComponent();

            Installers.Add(GetServiceInstaller());
            Installers.Add(GetServiceProcessInstaller());
        }

        public PlushHttpsServiceInstaller(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private static ServiceInstaller GetServiceInstaller()
        {
            Process pc = Process.GetCurrentProcess();
            Directory.SetCurrentDirectory
            (pc.MainModule.FileName.Substring(0, pc.MainModule.FileName.LastIndexOf(@"\", StringComparison.CurrentCulture)
            ));

            ServiceInstaller installer = new ServiceInstaller
            {
                ServiceName = "PlushHTTPS",
                Description = "PlushHTTPS"
            };

            return installer;
        }

        private static ServiceProcessInstaller GetServiceProcessInstaller()
        {
            ServiceProcessInstaller installer = new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem };
            return installer;
        }
    }
}
