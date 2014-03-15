﻿using System;
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

namespace server
{
    public partial class Form1 : Form
    {
        bool listen = true;
            Dictionary<string, string> users = new Dictionary<string, string>();
            Dictionary<string, object> klienter = new Dictionary<string, object>();
            private TcpListener tcpListener; //A tcplistener.
            private Thread listenThread; //A listenthread
            string username;
            string test;
            
        public Form1()
        {
            InitializeComponent();
            this.tcpListener = new TcpListener(IPAddress.Any, 9999); //Creates a TCPlistener that listens for any Ipadress but port 9998.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
            users.Add("markus", "hejsan123");
            users.Add("martin", "hejsan321");
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
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
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
                    //blocks until a client sends a message
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
                string[] tmp = username.Split(' ');
                if (tmp[0] == "$")
                {
                    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                    {

                        klienter.Add(tmp[1], test);
                        string result = string.Join(", ", klienter.Select(x => string.Format("{0} : {1}", x.Key, x.Value)).ToArray());
                        byte[] buffer = encoder.GetBytes(result); //a byte array to store the message in after it has been encoded.
                        clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                        clientStream.Flush(); //Flushes the stream
                    }
                }
                if(tmp[0] == "#")
                {
                    users.Add(tmp[1], tmp[2]);
                }
            
                clientStream.Flush();
            }
            tcpClient.Close();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = klienter.Select(kv => kv.Key + ": " + kv.Value.ToString());
            textBox1.Text = string.Join(Environment.NewLine, lines);

            //var blines = users.Select(kv => kv.Key + ": " + kv.Value.ToString());
            //textBox1.Text = string.Join(Environment.NewLine, blines);
        }

    }
}