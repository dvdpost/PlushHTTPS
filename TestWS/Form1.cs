using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using PlushHTTPS.WCFHost;

namespace TestWS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            PlushHTTPS.WCFHost.WcfService srvc = new PlushHTTPS.WCFHost.WcfService();
            srvc.TVODPayAndGetVodTokenAuthXMLAndLngs(1486190, 0, 0, "11", "MASTERCARD", "5477501462948191", "1015", "Igor MP", "550", 131, 8);
        }
    }
}
