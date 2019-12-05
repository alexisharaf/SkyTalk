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

namespace SkyTalk
{
    public partial class SkyTalkClientMainForm : Form
    {

        public SkyTalkClientMainForm()
        {
            InitializeComponent();

        }

        private void connectToServerButton_Click(object sender, EventArgs e)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            IPAddress ipAddr = IPAddress.Parse(serverIpTextBox.Text);
           

            // Устанавливаем удаленную точку для сокета
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11111);

            string message = "Привет";

            try
            {

                //Создаем сокет
                Socket socketsender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                socketsender.Connect(ipEndPoint);

              // do
               // {

                    //Console.Write("Введите сообщение: ");
                    //message = Console.ReadLine();

                    //Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
                    byte[] msg = Encoding.UTF8.GetBytes(message);

                MessageClass mess = new MessageClass();

                mess.User = "user1";
                mess.Password = "pass";
                mess.Command = "Connect";
                mess.Data = "fdgfdgdfgfd";

                BinaryFormatter serializer = new BinaryFormatter();

                MemoryStream mem_stream = new MemoryStream();
                serializer.Serialize(mem_stream, mess);

                
                // Отправляем данные через сокет
                int bytesSent = socketsender.Send(mem_stream.GetBuffer());


             
                
                    // Получаем ответ от сервера
                    int bytesRec = socketsender.Receive(bytes);
                
                    string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                userListListBox.Items.Add(data);


               // }
               // while (message.IndexOf("#END#") == -1);

                // Освобождаем сокет
                socketsender.Shutdown(SocketShutdown.Both);
                socketsender.Close();

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
