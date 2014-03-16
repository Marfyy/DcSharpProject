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
using System.IO;
namespace DcSharpProject
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        Thread listenThread;

        ServerConnector serverConn;
        ClientConnector clientConn;
        bool listen = true;
        public Form1()
        {
            InitializeComponent();
            serverConn = new ServerConnector();
            clientConn = new ClientConnector();
            this.tcpListener = new TcpListener(IPAddress.Any, 9999); //Creates a TCPlistener that listens for any Ipadress but port 9998.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
            clientConn.sendCompleteFile(@"C:\Users\Martin\Videos\Inside Zone Techniques.mp4", new Client("127.0.0.1", 9999));
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

            // If we've been passed an unhelpful initial length, just
            // use 32K.
    
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            int read=0;
            bool done = false;
            int chunk;
            byte[] output;
            while ( (chunk = clientStream.Read(buffer, read, buffer.Length-read)) > 0)
            {
                read += chunk;
        
                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = clientStream.ReadByte();
            
                    // End of stream? If so, we're done
                    if (nextByte==-1)
                    {
                        done = true;
                        output = buffer;
                        File.WriteAllBytes(@"C:\asdf.jpg", output);
                        break;
                    }
            
                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length*2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read]=(byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
                if (done == false)
                {
                    // Buffer is now too big. Shrink it.
                    output = new byte[read];
                    Array.Copy(buffer, output, read);
                    File.WriteAllBytes(@"C:\asdf.jpg", output);
                }
                














            //byte[] message = new byte[4096]; //array of bytes to store message in
            //byte[] totalMessage = new byte[1];
            //int bytesRead; //an int that stores bytes read.

            //while (clientStream.CanRead)
            //{
            //    bytesRead = 0;
            //    Thread.Sleep(10);
            //    try
            //    {
            //        //blocks until a client sends a message
            //        bytesRead = clientStream.Read(message, 0, 4096);
                    
            //    }
            //    catch
            //    {
            //        //a socket error has occured
            //        break;
            //    }

            //    if (bytesRead == 0)
            //    {
            //        //the client has disconnected from the server
            //        File.WriteAllBytes(@"C:\asdf.jpg", totalMessage);
            //        break;
            //    }
            //    else
            //        totalMessage = mergeData(totalMessage, message);

                
                //test = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

                ////message has successfully been received
                //ASCIIEncoding encoder = new ASCIIEncoding();
                //username = (encoder.GetString(message, 0, bytesRead));
                //string[] tmp = username.Split(' ');
                //if (tmp[0] == "$")
                //{
                //    if (users.ContainsKey(tmp[1]) && users.ContainsValue(tmp[2]))
                //    {

                //        klienter.Add(tmp[1], test);
                //        string result = string.Join(", ", klienter.Select(x => string.Format("{0} : {1}", x.Key, x.Value)).ToArray());
                //        byte[] buffer = encoder.GetBytes(result); //a byte array to store the message in after it has been encoded.
                //        clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                //        clientStream.Flush(); //Flushes the stream
                //    }
                //}
                //if (tmp[0] == "#")
                //{
                //    users.Add(tmp[1], tmp[2]);
                //}

                clientStream.Flush();
            }
            tcpClient.Close();
        }
        private byte[] mergeData(byte[] data1, byte[] data2)
        {
            int array1OriginalLength = data1.Length;
            Array.Resize<byte>(ref data1, array1OriginalLength + data2.Length);
            Array.Copy(data2, 0, data1, array1OriginalLength, data2.Length);
            return data1;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Server server = new Server("asdf", "213.100.234.13", 9999, "asdf", "asdf");
            serverConn.loginToServer(server);
        }
    }
}
