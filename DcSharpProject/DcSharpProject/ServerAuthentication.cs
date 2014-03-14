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

        public bool logonToServer(string serverIP, int serverPort, string userIP, int userPort, string userName, string userPassword)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] IP = encoder.GetBytes(serverIP);
            TcpListener listener = new TcpListener(new IPAddress(IP), serverPort);
            string message = "$ " + userName + " " + userPassword + " " + userIP + " " + userPort;
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
                server = listener.AcceptTcpClient();
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
            return false;
        }
        public bool logoutFromServer(ConnectedServer server)
        {
            return false;
        }
    }
}
