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
using System.Net.WebSockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace SkyTalk
{
    public partial class SkyTalkClientMainForm : Form
    {

        IPHostEntry localIPHost;
        IPAddress localipAddr;


        public SkyTalkClientMainForm()
        {
            InitializeComponent();




            localIPHost = Dns.GetHostEntry(Dns.GetHostName());
            //ipAddr = ipHost.AddressList[0];

            for (int i = 0; i < localIPHost.AddressList.Length; i++)
            {
                localIPcomboBox.Items.Add(localIPHost.AddressList[i].ToString());
            }



        }

        private void connectToServerButton_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[65000];

            localipAddr = localIPHost.AddressList[localIPcomboBox.SelectedIndex];


            // Соединяемся с удаленным устройством

            IPAddress remoteipAddr = IPAddress.Parse(serverIpTextBox.Text);
           

            // Устанавливаем удаленную точку для сокета
            IPEndPoint remoteipEndPoint = new IPEndPoint(remoteipAddr, 11111);

            string message = "Привет";

            try
            {                //Создаем сокет
                Socket socketsender = new Socket(remoteipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                socketsender.Connect(remoteipEndPoint);

              // do
               // {

                    //Console.Write("Введите сообщение: ");
                    //message = Console.ReadLine();

                    //Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
                    byte[] msg = Encoding.UTF8.GetBytes(message);

                MessageClass mess = new MessageClass();

                mess.User = userNameTextBox.Text.Trim();
                mess.Password = passTextBox.Text.Trim();
                mess.Command = "Connect";
                mess.Data = localipAddr.ToString();

                BinaryFormatter serializer = new BinaryFormatter();

                MemoryStream mem_stream = new MemoryStream();
                serializer.Serialize(mem_stream, mess);

                
                // Отправляем данные через сокет
                int bytesSent = socketsender.Send(mem_stream.GetBuffer());

                Thread.Sleep(500);

               

                    // Получаем ответ от сервера
                int bytesRec = socketsender.Receive(bytes);

                MessageClass ansmessage = null;
                 if (bytesRec > 0)
                 {


                     MemoryStream ans_mem_stream = new MemoryStream(bytes);
                     BinaryFormatter formatter = new BinaryFormatter();
                                       
                     ansmessage = (MessageClass)formatter.Deserialize(ans_mem_stream);
                 }

                //string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                userListListBox.Items.Add(ansmessage.Data);


               // }
               // while (message.IndexOf("#END#") == -1);

                // Освобождаем сокет
                socketsender.Shutdown(SocketShutdown.Both);
                socketsender.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
    }
}
