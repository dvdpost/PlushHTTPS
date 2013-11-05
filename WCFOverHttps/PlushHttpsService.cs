using System;
using System.ServiceModel;
using System.ServiceProcess;
using PlushHTTPS.WCFHost;

namespace PlushHTTPS
{
    public partial class PlushHttpsService : ServiceBase
    {
        private ServiceHost m_host;

        public PlushHttpsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartWcfService();
        }

        protected override void OnStop()
        {
            try
            {
                if (m_host != null)
                {
                    m_host.Close();
                    m_host = null;
                }
            }
            catch(Exception ex)
            {
                //handle exception
            }
        }

        private void StartWcfService()
        {
            m_host = new ServiceHost(typeof(WcfService));
            m_host.Open();
        }
    }
}
