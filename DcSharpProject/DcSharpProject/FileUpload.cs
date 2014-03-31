using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class FileUpload
    {
        public string fileURL { get; set; }
        public Client connectedClient { get; set; }
        public bool done { get; set; }
        public FileUpload() { }
        public FileUpload(string url, Client client)
        {
            fileURL = url;
            connectedClient = client;
            done = false;
        }
        public void Done()
        {
            done = true;
        }
    }
}
