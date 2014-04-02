using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class FileUpload
    {
        public dirFile file { get; set; }
        public Client connectedClient { get; set; }
        public bool done { get; set; }
        public FileUpload() { }
        public FileUpload(dirFile file, Client client)
        {
            this.file = file;
            connectedClient = client;
            done = false;
        }
        public void Done()
        {
            done = true;
        }
    }
}
