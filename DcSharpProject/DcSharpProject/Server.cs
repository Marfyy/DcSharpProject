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
    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
