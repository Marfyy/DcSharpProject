using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class FileDownload
    {
        public dirFile file { get; set; }
        public string fileURL { get; set; }
        public Client connectedClient { get; set; }
        public bool done { get; set; }
        public FileDownload()
        {
            
        }
        public FileDownload(dirFile file, Client client)
        {
            this.file = file;
            this.connectedClient = client;
        }
        public void Done()
        {
            this.done = true;
        }
    }
}
