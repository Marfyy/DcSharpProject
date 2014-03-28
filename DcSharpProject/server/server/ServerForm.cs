using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace server
{
    public partial class ServerForm : Form
    {
        bool listen = true;
        Dictionary<string, string> users = new Dictionary<string, string>();
        Dictionary<string, object> klienter = new Dictionary<string, object>();
        private TcpListener tcpListener = new TcpListener(IPAddress.Any,9999); //A tcplistener.
        private Thread listenThread; //A listenthread
        private Thread heartbeatThread;
        string username;
        string test;
        int port;

        public ServerForm()
        {
            InitializeComponent();
            klienter.Add("Marreman", 1920301230);
            users.Add("markus", "hejsan123");
            users.Add("martin", "hejsan321");
            getservers();
            timer1.Interval = 19000;
            timer1.Start();
        }

        //A method that loops aslong as listen is true.
        public void ListenForClients() 
        {
            //starts the tcplistener
            this.tcpListener.Start(); 

            while (listen)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.IsBackground = true;
                clientThread.Start(client);
            }
        }
        public void HandleClientComm(object client) //This method handels the incoming messages.
        {
            TcpClient tcpClient = (TcpClient)client; //New tcp client
            NetworkStream clientStream = tcpClient.GetStream(); //new networkstream
            byte[] message = new byte[4096]; //array of bytes to store message in
            int bytesRead; //an int that stores bytes read.

            while (clientStream.CanRead)
            {
                bytesRead = 0;
                Thread.Sleep(10);
                try
                {
                    //blocks until a client sends a messages
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                test = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                username = (encoder.GetString(message, 0, bytesRead));
                string[] tmp = username.Split('|');
                string okMess = "@OK";
                byte[] okBuff;
                string nOk = "@NOK";
                byte[] nokBuff;
                if (tmp[0] == "$") // Logga in
                {

                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {
                        if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(test))
                        {
                            klienter.Add(tmp[1], test);
                            string result = string.Join(", ", klienter.Select(x => string.Format("{0} : {1}", x.Key, x.Value)).ToArray());
                            byte[] buffer = encoder.GetBytes(result); //a byte array to store the message in after it has been encoded.
                            clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                            clientStream.Flush(); //Flushes the stream
                            okBuff = encoder.GetBytes(okMess);
                            clientStream.Write(okBuff, 0, okBuff.Length);
                            clientStream.Flush();
                        }
                        else
                        {
                            nokBuff = encoder.GetBytes(nOk);
                            clientStream.Write(nokBuff, 0, nokBuff.Length);
                            clientStream.Flush();
                        }
                    }
                }
                if (tmp[0] == "#") // Bli medlem
                {
                    if (!users.ContainsKey(tmp[1]) && !users.ContainsValue(tmp[2]))
                    {
                        users.Add(tmp[1], tmp[2]);
                        okBuff = encoder.GetBytes(okMess);
                        clientStream.Write(okBuff, 0, okBuff.Length);
                        clientStream.Flush();
                    }
                    else
                    {
                        nokBuff = encoder.GetBytes(nOk);
                        clientStream.Write(nokBuff, 0, nokBuff.Length);
                        clientStream.Flush();
                    }
                }
                if (tmp[0] == ",") // Skicka klientlistan till servrarna
                {
                    if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(tmp[2]))
                    {
                        klienter.Add(tmp[1], tmp[2]);
                    }
                }
                if (tmp[0] == "!")//Logga ut användaren
                {
                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {
                        klienter.Remove(tmp[1]);
                        klienter.Remove(test);
                        okBuff = encoder.GetBytes(okMess);
                        clientStream.Write(okBuff, 0, okBuff.Length);
                        clientStream.Flush();
                    }
                }
                if(tmp[0] == "%")
                {
                    //skicka lista över klienter till användaren...


                }
               

                clientStream.Flush();
            }
            tcpClient.Close();
        }
        public static bool PingHost(string _HostURI, int _PortNumber)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(_HostURI,_PortNumber);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error pinging host:'" + _HostURI + ":" + _PortNumber.ToString() + "'");
                
            }
            return false;
        }

        public void heartbeat()
        {
            string ip = "10.1.1.114";
            XDocument xmldoc = XDocument.Load("XMLFile1.xml");

            var test = (from p in xmldoc.Descendants("interface")
                        select int.Parse(p.Element("port").Value)).ToList();

            foreach (var item in test)
            {
                Debug.WriteLine("Compare my port " + port + " against item port " + item);

                if (item > port)
                {
                    bool resultPing = PingHost(ip, item);
                    Debug.WriteLine("Ping result" + resultPing);
                    if (!resultPing)
                    {
                        Debug.WriteLine("My port is " + port + ", switching to " + item);
                        port = item;
                        //listenThread.Abort();
                        connect(port);                       
                    }
                }

                if(item < port)
                {
                    bool resultPing = PingHost(ip, item);
                    if(resultPing)
                    {
                        TcpClient client = new TcpClient(ip, item);
                        NetworkStream clientStream = client.GetStream();
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string result = string.Join(",|", klienter.Select(x => string.Format("{0}|{1}|{2}", ",", x.Key, x.Value)).ToArray());
                        byte[] buffer = encoder.GetBytes(result); //a byte array to store the message in after it has been encoded.
                        clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                        clientStream.Flush();
                    }
                }
            }

            heartbeatThread.Abort();
        }

        private void btn_connClient_Click(object sender, EventArgs e)
        {
            var lines = klienter.Select(kv => kv.Key + ": " + kv.Value.ToString());
            textBox1.Text = string.Join(Environment.NewLine, lines);
        }

        private void portbtn_Click(object sender, EventArgs e)
        {
            port = int.Parse(portbox.Text);
            connect(port);
            portbox.Enabled = false;
            portbtn.Enabled = false;
        }

        private void connect(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port); //Creates a TCPlistener that listens for any Ipadress but port 9999.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
        }

        private void getservers()
        {
            XDocument xmldoc = XDocument.Load("XMLFile1.xml");
            var items = (from i in xmldoc.Descendants("interface")
                         select new { IpAdress = i.Element("IpAdress").Value, Port = i.Element("port").Value }).ToList();

            lst_serverlist.DataSource = items;
            lst_serverlist.DisplayMember = "IpAdress" + "port";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.heartbeatThread = new Thread(new ThreadStart(heartbeat)); //New thread that will listen for clients.
            this.heartbeatThread.IsBackground = true; //Sets the thread to a background process.
            this.heartbeatThread.Start(); //Starts the listenerthread.
        }

        private void btn_exitServer_Click(object sender, EventArgs e)
        {
           
            Environment.Exit(0);
        }

    }
}
