﻿using System;
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

        List <UserTreadSettingsClass> userslist;

        

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

        

            addLogDelegate = new AddLogItem(updatelog);


            commandThread = new Thread(ControlCommandsFlow);

            userslist = new List<UserTreadSettingsClass>();

            
            
        }


        private void updatelog(string msgtolog)
        {
            logTableAdapter.Insert(msgtolog, DateTime.Now);
            logTableAdapter.Fill(this.skytalkDataSet.log);

        }

        private void ControlCommandsFlow()
        {
            Socket handler = null;

          

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11100);

            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            MessageClass backmessage = new MessageClass();


            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);


                

                this.Invoke(this.addLogDelegate, "Запускаем сервер");

              
               
                while (true)
                {
                    // Начинаем слушать соединения
                    handler = sListener.Accept();
                   

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[65000];
                    int bytesRec = handler.Receive(bytes);

                   

                    if (bytesRec != 0)
                    {
                        MemoryStream mem_stream = new MemoryStream(bytes);
                        BinaryFormatter formatter = new BinaryFormatter();

                       


                        MessageClass message = (MessageClass)formatter.Deserialize(mem_stream);

                        this.Invoke(this.addLogDelegate, "Подключился пользователь " + message.User.ToString());
                        this.Invoke(this.addLogDelegate, "С паролем " + message.Password.ToString());
                        this.Invoke(this.addLogDelegate, "С командой " + message.Command.ToString());
                        this.Invoke(this.addLogDelegate, "С адреса "  + message.Data.ToString());


                        if (message.Command.Equals("Connect") == true)
                        {

                            int index = this.usersBindingSource.Find("username", message.User);

                            if (index > -1)
                            {
                                if (skytalkDataSet.users.Rows[index]["password"].Equals(message.Password) == true)
                                {
                                    backmessage.Command = "Connect";

                                    UserTreadSettingsClass ut = new UserTreadSettingsClass();

                                    ut.username = message.User;
                                    ut.ipadr = message.Data;
                                    ut.port = userslist.Count + 11101;

                                    userslist.Add(ut);

                                    backmessage.Data = ut.port.ToString();

                                    //ThreadPool.QueueUserWorkItem(userthread, ut);

                                    //на каждого клента будет запускаться отдельный поток с отдельным новым сокетом на индивидуальном порту.
                                    //возможно я не прав, и есть другой путь.
                                    // номера портов 11101 - первый пользователь
                                    //11102  - второй пользователь и тд.
                                    // этот поток на порту 11100 только для подключения и авторизации новых клиентов


                                    //TODO пользователь может залогиниться несколько раз. Сделать проверку
                                }
                                else
                                {
                                    backmessage.Command = "PasswordWrong";
                                    backmessage.Data = "Плохой пароль";
                                    this.Invoke(this.addLogDelegate, "Плохой пароль ");
                                }
                            }
                            else
                            {
                                backmessage.Command = "ConnectWrong";
                                backmessage.Data = "Пользователь не найден";
                                this.Invoke(this.addLogDelegate, "Пользователь не найден ");
                            }
                        }

                        if(message.Command.Equals("GetUsersList") == true)
                        {
                            backmessage.Command = "GetUsersList";
                            backmessage.Data = null;

                            for (int i = 0; i < userslist.Count; i++)
                            {
                                backmessage.Data += userslist[i].username + ";";
                            }
                        }


                        if(message.Command.Equals("CallUser") == true)
                        {
                          
                            backmessage.Data =  userslist.Find(x => x.username.Equals(message.Data)).ipadr;
                            
                        }

                        // logListBox.BeginInvoke((Action)delegate () { logListBox.Items.Add(message.User.ToString()); });
                        

                        backmessage.User = message.User;
                        backmessage.Password = "";

                        BinaryFormatter serializer = new BinaryFormatter();

                        MemoryStream ans_mem_stream = new MemoryStream();
                        serializer.Serialize(ans_mem_stream, backmessage);


                        handler.Send(ans_mem_stream.GetBuffer());

                      

                    }
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                   handler.Shutdown(SocketShutdown.Both);
                   handler.Close();

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


        private  void userthread(object stateInfo)
        {

        }

       
    }
}
