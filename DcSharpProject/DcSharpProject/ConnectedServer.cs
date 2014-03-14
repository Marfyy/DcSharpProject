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
    class ConnectedServer
    {
        public string IP { get; private set; }
        public string Port { get; private set; }
        public string userName { get; private set; }
        public string password { get; private set; }

        public ConnectedServer()
        {

        }
  
    }
}
