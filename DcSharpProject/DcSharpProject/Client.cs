using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    public class Client
    {
        public string IP { get; set; }
        public int Port { get; set; }

        public Client(string IP, int port)
        {
            this.IP = IP;
            this.Port = port;
        }
        public Client(EndPoint endpoint)
        {
            string address = endpoint.ToString();
            string[] split = address.Split(new char[] { ':' });
            this.IP = split[0];
            this.Port = int.Parse(split[1]);
        }
    }
}
