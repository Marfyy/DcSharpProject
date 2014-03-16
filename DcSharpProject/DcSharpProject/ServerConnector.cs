using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

//$ = inlogg
//# = registrering
//¤ = utlogg
//% = hämta användarlista
//@ = hämta en användares IP och port
namespace DcSharpProject
{
    /// <summary>
    /// Organizes the connections to a dC# server
    /// </summary>
    class ServerConnector
    {
        TcpListener listener;
        /// <summary>
        /// Sends a login message to a given server, which contains username and password
        /// </summary>
        /// <param name="serverToConnect"></param>
        /// <returns>Server message</returns>
        public string loginToServer(Server serverToConnect)
        {
            string sendMessage = "$ " + serverToConnect.UserName + " " + serverToConnect.Password;
            return sendMessageReturn(serverToConnect, sendMessage);
        }        
        /// <summary>
        /// Sends a logout message to a given server, which contains username and password
        /// </summary>
        /// <param name="serverToDisconnect"></param>
        /// <returns>Server message</returns>
        public string logoutFromServer(Server serverToDisconnect)
        {
            string sendMessage = "¤ " + serverToDisconnect.UserName + " " + serverToDisconnect.Password;
            return sendMessageReturn(serverToDisconnect, sendMessage);
        }
        /// <summary>
        /// Sends a register message to a given server, containing username and password
        /// </summary>
        /// <param name="serverToRegister"></param>
        /// <returns>Server message</returns>
        public string registerToServer(Server serverToRegister)
        {
            string sendMessage = "# " + serverToRegister.UserName + " " + serverToRegister.Password;
            return sendMessageReturn(serverToRegister, sendMessage);
        }
        /// <summary>
        /// Sends a get user list message to a given server, containing username and password
        /// </summary>
        /// <param name="serverToReceive"></param>
        /// <returns>if auth checks out, the userlist from the server</returns>
        public string getCompleteUserListFromServer(Server serverToReceive)
        {
            string sendMessage = "% " + serverToReceive.UserName + " " + serverToReceive.Password;
            return sendMessageReturn(serverToReceive, sendMessage);
        }
        public string getUserConnInfo(Server serverToReceive, string srcUsername)
        {
            string sendMessage = "@ " + serverToReceive.UserName + " " + serverToReceive.Password + " " + srcUsername;
            return sendMessageReturn(serverToReceive, sendMessage);
        }
        /// <summary>
        /// Sends a message to given server containing sendMessage, and expecting receiveMessage from server back. 10 second timeout.
        /// </summary>
        /// <param name="serverToConnect"></param>
        /// <param name="sendMessage"></param>
        /// <param name="receiveMessage"></param>
        /// <returns></returns>
        private string sendMessageReturn(Server serverToConnect, string sendMessage)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] IP = encoder.GetBytes(serverToConnect.IP);
            listener = new TcpListener(IPAddress.Parse(serverToConnect.IP), serverToConnect.Port);
            string message = "";
            try
            {
                //SEND LOGIN MESSAGE TO SERVER
                TcpClient server = new TcpClient(serverToConnect.IP, serverToConnect.Port);
                NetworkStream stream = server.GetStream();
                byte[] bMessage = encoder.GetBytes(sendMessage);
                stream.Write(bMessage, 0, bMessage.Length);
                stream.Flush();

                //RECIEVE OK FROM SERVER
                listener.Start();
                Thread timeoutThread = new Thread(new ThreadStart(AuthenticationTimeout)); //Makes the client wait 10 seconds for the server to respond to the login, else abort
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
        /// <summary>
        /// Sends a logout message to a given server, which contains username and password
        /// </summary>
        /// <param name="serverToDisconnect"></param>
        /// <returns></returns>
    }
}
