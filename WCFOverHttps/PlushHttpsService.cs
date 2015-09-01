using System;
using System.ServiceModel;
using System.ServiceProcess;
using PlushHTTPS.WCFHost;
using System.Net.Mail;

namespace PlushHTTPS
{
    public partial class PlushHttpsService : ServiceBase
    {
        private ServiceHost m_host;
        private System.Diagnostics.EventLog _hosteventLog;

        public PlushHttpsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartWcfService();
        }

        private void SendMail(string poruka)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";

            client.Port = 587;
            client.EnableSsl = true;


            // The server requires user's credentials
            // not the default credentials
            //client.UseDefaultCredentials = false;
            // Provide your credentials
            client.Credentials = new System.Net.NetworkCredential("igor.markovic@dvdpost.be", "Vcxsw234");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;

            // Use SendAsync to send the message asynchronously
            try
            {
                client.Send("igor.markovic@dvdpost.be", "igor.markovic@dvdpost.be", "PlushHTTPS Service Stopped", "PlushHTTPS Service Stopped" + DateTime.Now.ToString());
            }
            catch (Exception)
            {
                _hosteventLog.WriteEntry("PlushHTTPS Service STOP - email does not sent");
            }

        }

        protected override void OnStop()
        {
            this._hosteventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            _hosteventLog.Source = "PlushHTTPSServiceSource";
            _hosteventLog.Log = "PlushHTTPSServiceLog";

            SendMail("");
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
                _hosteventLog.WriteEntry("OnStop.Exception: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        private void StartWcfService()
        {
            m_host = new ServiceHost(typeof(WcfService));
            m_host.Open();
        }
    }
}
