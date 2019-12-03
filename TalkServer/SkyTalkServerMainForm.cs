using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SkyTalk
{
    public partial class SkyTalkServerMainForm : Form
    {

        IPHostEntry ipHost;
        IPAddress ipAddr;

        public SkyTalkServerMainForm()
        {

            InitializeComponent();

            hostNameTextBox.Text = Dns.GetHostName();

            ipHost = Dns.GetHostEntry(Dns.GetHostName());
            //ipAddr = ipHost.AddressList[0];

            for (int i = 0; i < ipHost.AddressList.Length; i++)
            {
                ipAdressComboBox.Items.Add(ipHost.AddressList[i].ToString());

                 
            }
            
           // IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11111);

        }

        private void startServerButton_Click(object sender, EventArgs e)
        {


            ipAddr = ipHost.AddressList[ipAdressComboBox.SelectedIndex - 1];

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, Convert.ToInt32(portNumberTextBox.Text));
            
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);


            Socket handler = sListener.Accept();


        }
    }
}
