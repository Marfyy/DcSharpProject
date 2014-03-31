using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    [Serializable]
    class dirFile
    {
        public string Name { get; set; }
        public int sizeMB { get; set; }
        public string internalURL { get; set; }
        public string realURL { get; set; }
        public dirFile()
        {
        }
        public dirFile(string name, int size, string url, string realurl)
        {
            this.Name = name;
            this.sizeMB = size;
            this.internalURL = url;
            this.realURL = realurl;
        }
    }
}
