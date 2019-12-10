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
        IPAddress remoteipAddr;
        IPEndPoint remoteipEndPoint;


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

        private MessageClass SendCommandToServer(MessageClass msgToServer)
        {
            MessageClass msgFromSrerver = null;

            // Буфер для входящих данных
            byte[] bytes = new byte[65000];

           

            // Соединяемся с удаленным устройством
           


            // Устанавливаем удаленную точку для сокета
            remoteipEndPoint = new IPEndPoint(remoteipAddr, 11100);


            try
            {                //Создаем сокет
                Socket socketsender = new Socket(remoteipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                socketsender.Connect(remoteipEndPoint);



            //    MessageClass mess = new MessageClass();

            //    mess.User = userNameTextBox.Text.Trim();
            //    mess.Password = passTextBox.Text.Trim();
            //    mess.Command = "Connect";
            //    mess.Data = localipAddr.ToString();

                BinaryFormatter serializer = new BinaryFormatter();

                MemoryStream mem_stream = new MemoryStream();
                serializer.Serialize(mem_stream, msgToServer);


                // Отправляем данные через сокет
                int bytesSent = socketsender.Send(mem_stream.GetBuffer());

                Thread.Sleep(500);



                // Получаем ответ от сервера
                int bytesRec = socketsender.Receive(bytes);

                //MessageClass ansmessage = null;
                if (bytesRec > 0)
                {


                    MemoryStream ans_mem_stream = new MemoryStream(bytes);
                    BinaryFormatter formatter = new BinaryFormatter();

                    msgFromSrerver = (MessageClass)formatter.Deserialize(ans_mem_stream);
                }

         //       if (ansmessage.Command.Equals("Connect") == true)
         //       {

         //           userListListBox.Items.Add(ansmessage.Data);
                    //Запускаем новый поток с новым сокетом, в котором будем дальше общаться с сервером 
         //       }
         //       else
         //       {
         //           MessageBox.Show(ansmessage.Data, ansmessage.Command);
         //       }



                // Освобождаем сокет
                socketsender.Shutdown(SocketShutdown.Both);
                socketsender.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




            return msgFromSrerver;
        }


        private void connectToServerButton_Click(object sender, EventArgs e)
        {

            localipAddr = localIPHost.AddressList[localIPcomboBox.SelectedIndex];
            remoteipAddr = IPAddress.Parse(serverIpTextBox.Text);

            MessageClass mess = new MessageClass();

            mess.User = userNameTextBox.Text.Trim();
            mess.Password = passTextBox.Text.Trim();
            mess.Command = "Connect";
            mess.Data = localipAddr.ToString();



            MessageClass ansmessage = SendCommandToServer(mess);
                 
            if (ansmessage.Command.Equals("Connect") == true)
            {

                userListListBox.Items.Add(ansmessage.Data);
                    //Запускаем новый поток с новым сокетом, в котором будем дальше общаться с сервером 
            }
            else
            {
                MessageBox.Show(ansmessage.Data, ansmessage.Command);
            }

           
        }

        private void getUsersListButton_Click(object sender, EventArgs e)
        {

            MessageClass mess = new MessageClass();

            mess.User = userNameTextBox.Text.Trim();
            mess.Password = passTextBox.Text.Trim();
            mess.Command = "GetUsersList";
            mess.Data = localipAddr.ToString();



            MessageClass ansmessage = SendCommandToServer(mess);

            if (ansmessage.Command.Equals("GetUsersList") == true)
            {

                userListListBox.Items.Add(ansmessage.Data);
                //Запускаем новый поток с новым сокетом, в котором будем дальше общаться с сервером 
            }
            else
            {
                MessageBox.Show(ansmessage.Data, ansmessage.Command);
            }
        }
    }
}
