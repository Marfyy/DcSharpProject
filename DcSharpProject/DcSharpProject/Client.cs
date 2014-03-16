using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class Client
    {
        public string IP { get; set; }
        public int Port { get; set; }

        public Client(string IP, int port)
        {
            this.IP = IP;
            this.Port = port;
        }
    }
}
