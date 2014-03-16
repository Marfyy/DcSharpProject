using System;
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

namespace DcSharpProject
{
    public partial class Form1 : Form
    {
        ServerAuthentication serverAuth;
        TcpListener tcpListener = new TcpListener(IPAddress.Any, 9999);
        bool listen = true;
        public Form1()
        {
            InitializeComponent();
            serverAuth = new ServerAuthentication();
            Thread getmessages = new Thread(new ThreadStart(ListenForClients)); //Starts the thread get messages as handleservercomm.
            getmessages.IsBackground = true; //Makes it a background process for correct shutdown of program.
            getmessages.Start(); //Starts the getmessages.
            
        }
        public void ListenForClients() //A method that loops aslong as listen is true.
        {
            this.tcpListener.Start(); //starts the tcplistener

            while (listen)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                ////create a thread to handle communication 
                //with connected client
                //Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                //clientThread.Start(client);

                MessageBox.Show("Connecting...");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            byte[] data = client.DownloadData(@"http://ipinfo.io/ip");
            string IP = ASCIIEncoding.ASCII.GetString(data); //Gets the external IP for the network, with a \n at the end
            IP = IP.Remove((IP.Length - 1)); //Removes the \n
            serverAuth.logonToServer("213.100.234.13", 9999, "asdf", "asdf");
        }
    }
}
