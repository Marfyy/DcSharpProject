using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

//! = FileDownloadRequest
//@ = SendDirectoryRequest
namespace DcSharpProject
{
    class ClientConnector
    {
        TcpListener listener;

        public string sendFileDownloadRequest(Client client, string fileRequested)
        {
            //Fixa så en port kommer med också
            string sendMessage = "!|" + fileRequested;
            return sendMessageReturn(client, sendMessage);
        }
        public string sendFileDownloadResponse(Client client, string message)
        {
            string sendMessage = "%" + message;
            return sendMessageReturn(client, sendMessage);
        }
        public string sendDirectoryRequest(Client client)
        {
            string sendMessage = "@";
            return sendMessageReturn(client, sendMessage);
        }
        public void sendFile(string URI, int offset, Client client)
        {
            try
            {
                TcpClient receiverClient = new TcpClient(client.IP, client.Port);
                NetworkStream receiverStream = receiverClient.GetStream();
                byte[] data = File.ReadAllBytes(URI);
                FileStream file = new FileStream(URI, FileMode.Open);
                file.Seek((long)offset, SeekOrigin.Begin);
                file.CopyTo(receiverStream, receiverClient.ReceiveBufferSize);             
            }
            catch(SocketException)
            {
                //Lost connection
            }
        }
        //För att kontrollera redan nerladdad data, hasha alla färdiga paket, skicka nycklarna och paketnr till klient. klient svarar med vilka paket som den vill ha
        public void sendPartialFile(string URI, int offset, Client client)
        {
            TcpClient receiverClient = new TcpClient(client.IP, client.Port);
            NetworkStream receiverStream = receiverClient.GetStream();
            byte[] data = File.ReadAllBytes(URI);
            FileStream file = new FileStream(URI, FileMode.Open);
            file.CopyTo(receiverStream);
        }

        public void sendUserDirectory(User user, TcpClient client)
        {
            MemoryStream stream = user.getDirectoryData();
            NetworkStream receiverStream = client.GetStream();
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(receiverStream, client.ReceiveBufferSize);
        }
        private string sendMessageReturn(Client clientToConnect, string sendMessage)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] IP = encoder.GetBytes(clientToConnect.IP);
            listener = new TcpListener(IPAddress.Parse(clientToConnect.IP), clientToConnect.Port);
            string message = "";
            try
            {
                //SEND MESSAGE TO SERVER
                TcpClient server = new TcpClient(clientToConnect.IP, clientToConnect.Port);
                NetworkStream stream = server.GetStream();
                byte[] bMessage = encoder.GetBytes(sendMessage);
                stream.Write(bMessage, 0, bMessage.Length);
                stream.Flush();

                //RECIEVE RESPONSE FROM SERVER
                listener.Start();
                Thread timeoutThread = new Thread(new ThreadStart(AuthenticationTimeout)); //Makes the client wait 10 seconds for the server to respond to the message, else abort
                timeoutThread.Start();
                server = listener.AcceptTcpClient();
                timeoutThread.Abort();
                stream = server.GetStream();
                int bytesRead;
                while (stream.CanRead)
                {
                    bytesRead = stream.Read(bMessage, 0, bMessage.Length);
                    if (bytesRead == 0)
                        break;
                    else
                    {
                        message += encoder.GetString(bMessage);
                    }
                }
            }
            catch (Exception)
            {
                return "Connection failure";
            }
            return message;
        }
        /// <summary>
        /// Creates a 10 second delay, then terminates the listener. Used for ack packages from server
        /// </summary>
        private void AuthenticationTimeout()
        {
            Thread.Sleep(10000);
            listener.Server.Close();
        }
    }
}
