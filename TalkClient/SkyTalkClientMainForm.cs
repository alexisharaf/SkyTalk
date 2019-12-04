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

            string message = "#END#";

            try
            {

                //Создаем сокет
                Socket socketsender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                socketsender.Connect(ipEndPoint);

                do
                {

                    //Console.Write("Введите сообщение: ");
                    //message = Console.ReadLine();

                    //Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
                    byte[] msg = Encoding.UTF8.GetBytes(message);

                    // Отправляем данные через сокет
                    int bytesSent = socketsender.Send(msg);

                    // Получаем ответ от сервера
                    int bytesRec = socketsender.Receive(bytes);

                    //Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));


                }
                while (message.IndexOf("#END#") == -1);

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
