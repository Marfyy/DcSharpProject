using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    /// <summary>
    /// Stores the information about a server that the client is connected to.
    /// </summary>
    class Server
    {
        public string Name { get; private set; }
        public string IP { get; private set; }
        public int Port { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public List<User> users;

        public Server(string name, string IP, int port, string username, string password)
        {
            this.Name = name;
            this.IP = IP;
            this.Port = port;
            this.UserName = username;
            this.Password = password;
            users = new List<User>();
        }
        public Server(string name, string IP, int port, string username, string password, List<User> users)
        {
            this.Name = name;
            this.IP = IP;
            this.Port = port;
            this.UserName = username;
            this.Password = password;
            this.users = users;
        }
        public string[] getUserNames()
        {
            string[] output = new string[users.Count];
            for(int i = 0; i < output.Length; i++)
            {
                output[i] = users[i].Name;
            }
            return output;
        }
  
    }
}
