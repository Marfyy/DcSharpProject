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

        //TESTKOD
        public override string ToString()
        {
            
            string downloads = string.Empty;
            downloads = string.Format("{0,-8}{1,12}", file, done);

            return downloads;
        }
    }
}
