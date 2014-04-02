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
        bool listen = true; //a bool for the listener.
        Dictionary<string, string> users = new Dictionary<string, string>(); //the dictionary with the registered users. (username, password).
        Dictionary<string, IPEndPoint> klienter = new Dictionary<string, IPEndPoint>(); //the dictionary containing users that are logged in. (username, ipendpoint).
        private TcpListener tcpListener = new TcpListener(IPAddress.Any,9999); //A new instance of a tcplistener that listenes to any ip on port 9999.
        private Thread listenThread; //A thread dedicated for the listener.
        private Thread heartbeatThread; //A thread dedicated for the heartbeat method.
        
        string username; //String containing username.
        int port; // String Containing Port.
        string ip = "10.1.1.114"; // Hardcoded port for our server. (Can be changed)

        public ServerForm()
        {
            InitializeComponent();
            var UserList = @"UserListXML.xml"; //List of users in XML document that later binds with the dictionary.
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("123123"), 9979); //Test ip endpoint used in project.
            var xdoc = XDocument.Load(UserList); //Loads the XML document containing users.
            users = xdoc.Descendants("user").ToDictionary(d => (string)d.Attribute("Username").Value,
                                                           d => (string)d.Attribute("Password").Value); //Gets all the users from XMl document and puts them in dictionary.
            getservers(); //Calls for a method that loads all the other servers from XML document.
            SetPort(ip, 9999); //Calls for method that sets the port. It tries port 9999 at first.
            timer1.Interval = 19000; //A timer interval for the heartbeat method.
            timer1.Start(); //Starts the timer.
        }

        public void SetPort(string ip, int port1) //A method that sets the port from 9999-9995. It tries from high to low.
        {
            if(PingHost(ip,port1))
            {
                port1--;
                if (port1 == 9994)
                {
                    MessageBox.Show("All ports are taken");
                    Environment.Exit(1);
                }
                else
                    SetPort(ip, port1);
            }
            else
            {
                port = port1;
                connect(port);
                lbn_port1.Text = port.ToString();
                return;
            }
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

                IPEndPoint connectedClient = ((IPEndPoint)tcpClient.Client.RemoteEndPoint);

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                username = (encoder.GetString(message, 0, bytesRead)); //gets the message.
                string[] tmp = username.Split('|'); //splits the message and splits it on |. 
                string okMess = tmp[0] + "OK"; //Premade confirmation message.
                byte[] okBuff; //premade confirmation buff.
                string nOk = tmp[0] + "NOK"; //Premade denial message.
                byte[] nokBuff; //Premade denial message.
                if (tmp[0] == "$") // Log in
                {

                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2])) // if the dictionary users already contain the username and password.
                    {
                        if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(connectedClient)) //If klienter doesnt have the username and password, it adds it.
                        {
                            klienter.Add(tmp[1], connectedClient);
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
                if (tmp[0] == "#") // Register
                {
                    if (!users.ContainsKey(tmp[1]) && !users.ContainsValue(tmp[2])) //if the users dictionary doesnt already contain username and password.
                    {
                        if (tmp[1] != null && tmp[2] != null) //if username and password isnt null, it adds the values to XML doc and dictionary.
                        {
                            var UserList = @"UserListXML.xml";
                            var newUser = new XElement("user");
                            newUser.SetAttributeValue("Username", tmp[1]);
                            newUser.SetAttributeValue("Password", tmp[2]);
                            var document = XDocument.Load(UserList);
                            var Users = document.Element("users");
                            Users.Add(newUser);
                            File.WriteAllText(UserList, document.ToString());
                            document.Save(UserList);
                            var xdoc = XDocument.Load(UserList);
                            users = xdoc.Descendants("user").ToDictionary(d => (string)d.Attribute("Username").Value,
                                                                           d => (string)d.Attribute("Password").Value);
                            okBuff = encoder.GetBytes(okMess);
                            clientStream.Write(okBuff, 0, okBuff.Length);
                            clientStream.Flush();
                        }
                    }
                    else
                    {
                        nokBuff = encoder.GetBytes(nOk);
                        clientStream.Write(nokBuff, 0, nokBuff.Length);
                        clientStream.Flush();
                    }
                }
                if (tmp[0] == ",") // Send klients to servers.
                {
                    if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(connectedClient))
                    {
                        klienter.Add(tmp[1], connectedClient);
                    }
                }
                if (tmp[0] == "!")//Log out.
                {
                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {
                        klienter.Remove(tmp[1]);
                        okBuff = encoder.GetBytes(okMess);
                        clientStream.Write(okBuff, 0, okBuff.Length);
                        clientStream.Flush();
                    }
                }
                if (tmp[0] == "+") //heartbeat from client, sends an ok message back.
                {
                    okBuff = encoder.GetBytes(okMess);
                    clientStream.Write(okBuff, 0, okBuff.Length);
                    clientStream.Flush();
                }
                if (tmp[0] == "%")
                {
                    //Send list of clients to user.
                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {
                        if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(connectedClient))
                        {
                            List<string> userNames = klienter.Keys.ToList<string>();
                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream();
                            formatter.Serialize(stream, userNames);
                            stream.Seek(0, SeekOrigin.Begin);
                            stream.CopyTo(clientStream);
                        }
                        else
                        {
                            nokBuff = encoder.GetBytes(nOk);
                            clientStream.Write(nokBuff, 0, nokBuff.Length);
                            clientStream.Flush();
                        }
                    }

                } if (tmp[0] == "@")//Get users ip and port.
                {
                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {
                        if (!klienter.ContainsKey(tmp[1]) && !klienter.ContainsValue(connectedClient))
                        {
                            string endpoint = "";
                            for (int i = 0; i < klienter.Count; i++)
                            {
                                if (klienter.Keys.ElementAt(i) == tmp[3])
                                    endpoint = klienter.Values.ElementAt(i).Address + "|" + klienter.Values.ElementAt(i).Port;
                            }
                            if (endpoint.CompareTo(String.Empty) == 0)
                            {
                                nokBuff = encoder.GetBytes(nOk);
                                clientStream.Write(nokBuff, 0, nokBuff.Length);
                                clientStream.Flush();
                            }
                            else
                            {
                                okBuff = encoder.GetBytes(okMess + "|" + endpoint);
                                clientStream.Write(okBuff, 0, okBuff.Length);
                                clientStream.Flush();
                            }
                        }
                        else
                        {
                            nokBuff = encoder.GetBytes(nOk);
                            clientStream.Write(nokBuff, 0, nokBuff.Length);
                            clientStream.Flush();
                        }
                    }


                    clientStream.Flush();
                }
                tcpClient.Close();
            }
        }
        public static bool PingHost(string _HostURI, int _PortNumber) //checks if an ip with a specific port is available.
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(_HostURI,_PortNumber);
                return true;
            }
            catch (Exception)
            {
                
            }
            return false;
        }

        public void heartbeat() //Checks if other servers are online. Otherwise it takes it place if it contains a higher portnumber.
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
                        connect(port);
                      
                    }
                }

                if(item < port) //sends klients to servers with lower port.
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

        private void connect(int port)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, port); //Creates a TCPlistener that listens for any Ipadress but port 9999.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
        }

        private void getservers() //Gets the servers from an XML document.
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
