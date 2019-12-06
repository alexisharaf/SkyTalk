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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SkyTalk
{
    public partial class SkyTalkServerMainForm : Form
    {

        IPHostEntry ipHost;
        IPAddress ipAddr;

        Thread commandThread;

        public delegate void AddLogItem(String myString);
        public AddLogItem addLogDelegate;

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

            addLogDelegate = new AddLogItem(updatelog);


            commandThread = new Thread(ControlCommandsFlow);
           // formatter = new BinaryFormatter();

        }


        private void updatelog(string msgtolog)
        {
            logTableAdapter.Insert(msgtolog, DateTime.Now);
            logTableAdapter.Fill(this.skytalkDataSet.log);

        }

        private void ControlCommandsFlow()
        {
            Socket handler = null;

            //ipAddr = ipHost.AddressList[ipAdressComboBox.SelectedIndex];

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);


                

                this.Invoke(this.addLogDelegate, "Запускаем сервер");

               

                
                // Начинаем слушать соединения
                while (true)
                {
                    handler = sListener.Accept();

                    //logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add("К серверу подключились. Получаем данные"); });
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[65000];
                    int bytesRec = handler.Receive(bytes);

                    //data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    if (bytesRec != 0)
                    {
                        MemoryStream mem_stream = new MemoryStream(bytes);
                        BinaryFormatter formatter = new BinaryFormatter();

                        //MessageClass message = new MessageClass();


                        MessageClass message = (MessageClass)formatter.Deserialize(mem_stream);

                       // logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add(message.User.ToString()); });
                       // logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add(message.Password.ToString()); });
                       // logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add(message.Command.ToString()); });
                       // logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add(message.Data.ToString()); });


                        // Отправляем ответ клиенту
                        string reply = "Получено символов: " + mem_stream.Length.ToString();

                        byte[] msg = Encoding.UTF8.GetBytes(reply);

                        handler.Send(msg);
                    }
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //   handler.Shutdown(SocketShutdown.Both);
                //   handler.Close();

                MessageBox.Show("Все пропало");
            }
        


        }




        private void startServerButton_Click(object sender, EventArgs e)
        {

            ipAddr = ipHost.AddressList[ipAdressComboBox.SelectedIndex];

            commandThread.Start();
            
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.skytalkDataSet);

        }

        private void SkyTalkServerMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'skytalkDataSet.log' table. You can move, or remove it, as needed.
            this.logTableAdapter.Fill(this.skytalkDataSet.log);
            // TODO: This line of code loads data into the 'skytalkDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.skytalkDataSet.users);

        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            NewUserForm nuf = new NewUserForm();

            if(nuf.ShowDialog() == DialogResult.OK)
            {
                usersTableAdapter.Insert(nuf.username, nuf.password);

                logTableAdapter.Insert("Зарегистрирован новый пользователь " + nuf.username, DateTime.Now);

            }

            usersTableAdapter.Fill(this.skytalkDataSet.users);
            logTableAdapter.Fill(this.skytalkDataSet.log);

        }

       
    }
}
