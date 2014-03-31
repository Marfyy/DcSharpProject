using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    [Serializable]
    public class dirFile
    {
        public string Name { get; set; }
        public int sizeMB { get; set; }
        public string URL { get; set; }
        public dirFile()
        {
        }
        public dirFile(string name, int size, string url)
        {
            this.Name = name;
            this.sizeMB = size;
            this.URL = url;
        }
    }
}
