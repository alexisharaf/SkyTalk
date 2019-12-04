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

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                userListListBox.Items.Add("data");
                logListBox.Items.Add("fjsdlkg");


                
                       Socket handler = sListener.Accept();

                       userListListBox.Items.Add("data");
                       logTextBox.Text += "data\n";

                       // Начинаем слушать соединения
                       while (true)
                       {

                           string data = null;

                           // Мы дождались клиента, пытающегося с нами соединиться

                           byte[] bytes = new byte[1024];
                           int bytesRec = handler.Receive(bytes);

                           data += Encoding.UTF8.GetString(bytes, 0, bytesRec);



                           // Отправляем ответ клиенту
                           string reply = "Получено символов: " + data.Length.ToString();

                           byte[] msg = Encoding.UTF8.GetBytes(reply);

                           handler.Send(msg);

                           if (data.IndexOf("#END#") > -1)
                           {
                               Console.WriteLine("Клиент отключился.");
                               break;
                           }


                       }

                       handler.Shutdown(SocketShutdown.Both);
                       handler.Close();
                       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }


        }
    }
}
