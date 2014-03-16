using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace DcSharpProject
{
    /// <summary>
    /// Organizes the authentication to a dC# server
    /// </summary>
    class ServerAuthentication
    {
        TcpListener listener;
        public bool logonToServer(string serverIP, int serverPort, string userName, string userPassword)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] IP = encoder.GetBytes(serverIP);
            listener = new TcpListener(IPAddress.Parse(serverIP), serverPort);
            string message = "$ " + userName + " " + userPassword;
            try
            {
                //SEND LOGIN MESSAGE TO SERVER
                TcpClient server = new TcpClient(serverIP, serverPort);
                NetworkStream stream = server.GetStream();
                byte[] bMessage = encoder.GetBytes(message);
                stream.Write(bMessage, 0, bMessage.Length);
                stream.Flush();

                //RECIEVE OK FROM SERVER
                listener.Server.ReceiveTimeout = 1000;
                listener.Server.SendTimeout = 1000;
                listener.Start();
                Thread timeoutThread = new Thread(new ThreadStart(AuthenticationTimeout)); //Makes the client wait 10 seconds for the server to respond to the login, else abort
                timeoutThread.Start();
                server = listener.AcceptTcpClient();
                timeoutThread.Abort();
                stream = server.GetStream();
                stream.ReadTimeout = 1000;
                int bytesRead;
                message = "";
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
                if (message.CompareTo("OK") == 0)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private void AuthenticationTimeout()
        {
            Thread.Sleep(10000);
            listener.Server.Close();
        }
        public bool logoutFromServer(ConnectedServer server)
        {
            return false;
        }
    }
}
