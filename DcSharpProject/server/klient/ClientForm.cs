using System;
using System.IO;
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

namespace klient
{
    public partial class ClientForm : Form
    {
        string ip;
        int port;
        protected TcpClient client;// = new TcpClient(); //New instance of a tcpclient (client)
        protected IPEndPoint serverEndPoint;// = new IPEndPoint(IPAddress.Parse(ip), port); //Defining the ip and port to server for later use.
        private Thread getmessages; //A thread that will be used to continiously read from the server.
        bool connected;
        //int prevport = 9999;
        public ClientForm()
        {
            InitializeComponent();

        }

        private void handleservercomm() //This method is used to read incoming messages from the server
        {
            try
            {
                NetworkStream clientStream = client.GetStream(); // creates a networkstream from the client.


                ASCIIEncoding encoder = new ASCIIEncoding(); //Creates a simple ASCII Encoder to "unpack" the incomming messages from bytes.
                clientStream.ReadTimeout = 100; // sets a timeout at 100 miliseconds.

                byte[] response = new byte[4096]; //Creates a bytearray to store the incoming message in.
                int bytesRead = 0; // an integer that will be used to check how much data that has been read.

                while (clientStream.CanRead) //aslong as the clientstream can read from the server, this loop will be alive.
                {
                    bytesRead = 0; //sets the bytes read to zero from beginning.
                    Thread.Sleep(10); //suspends the thread for 10 milliseconds.
                    try
                    {
                        bytesRead = clientStream.Read(response, 0, 4096); //Tries to read from the stream.
                    }
                    catch
                    {
                        break; //breaks if something goes wrong.
                    }
                    if (bytesRead == 0) //if no bytes are read, break.
                    {
                        break;
                    }
                    string msg = encoder.GetString(response, 0, bytesRead); //saves the incoming message into a string called msg. It uses the ASCII Encoder.
                    SetText(msg); //Sends the message to an invoke class. This is because the value comes from a different place.
                    clientStream.Flush(); //Flushes the clientstream.
                }
            }
            catch
            {
                connect("10.1.1.114",9999);
            }
        }

        delegate void SetTextCallback(string text);
        ASCIIEncoding en = new ASCIIEncoding();
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txt_connClient.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_connClient.Text += (text + " " + Environment.NewLine); //Adds the given line to the big textbox + datetime.
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "$|" + txt_username.Text + "|" + txt_password.Text; //stores the nickname to a string called message. 
            NetworkStream clientStream = client.GetStream(); //creates a networkstream from client.
            ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
            byte[] buffer = encoder.GetBytes(message); //bytearray to store the username message

            clientStream.Write(buffer, 0, buffer.Length); //sends username to server
            clientStream.Flush(); //flushes the stream.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "#|" + txt_userregister.Text + "|" + txt_passregister.Text; //stores the nickname to a string called message. 
            NetworkStream clientStream = client.GetStream(); //creates a networkstream from client.
            ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
            byte[] buffer = encoder.GetBytes(message); //bytearray to store the username message

            clientStream.Write(buffer, 0, buffer.Length); //sends username to server
            clientStream.Flush(); //flushes the stream.
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            ip = "10.1.1.114";
            port = 9999;
            connect(ip, port);
        }
        public void connect(string ip, int port)
        {
            client = new TcpClient(); //New instance of a tcpclient (client)
            while (!connected)
            {
                try
                {
                    serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); //Defining the ip and port to server for later use.
                    client.Connect(serverEndPoint); //Connect to the pre-defined ip and port, which is the server.
                    connected = true;
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }

            this.getmessages = new Thread(new ThreadStart(handleservercomm)); //Starts the thread get messages as handleservercomm.
            this.getmessages.IsBackground = true; //Makes it a background process for correct shutdown of program.
            this.getmessages.Start(); //Starts the getmessages.
        }
    }
}
