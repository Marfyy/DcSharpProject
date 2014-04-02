using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    public class PortHandler
    {
        public int clientRequestPort = 9000;
        public int serverRequestPort = 9999;
        public int clientDataPortMin = 10001;
        public int clientDataPortMax = 10998;
        private List<int> ports;
        private List<int> usedPorts;
        public PortHandler()
        {
            ports = new List<int>();
            for (int i = clientDataPortMin; i <= clientDataPortMax; i++)
            {
                ports.Add(i);
            }
            usedPorts = new List<int>();
        }
        public int getPort()
        {
            for(int i = 0; i < ports.Count; i++)
            {
                if (!usedPorts.Contains(ports[i]))
                {
                    usedPorts.Add(ports[i]);
                    return ports[i];
                }
            }
            return -1;
        }
        public void recyclePort(int port)
        {
            if (usedPorts.Contains(port))
                usedPorts.Remove(port);
        }
    }
}
