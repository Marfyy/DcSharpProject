using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    [Serializable]
    class Folder
    {
        public string Name { get; private set; }
        public List<string> files;
        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<string>();
        }
        public Folder(string name, List<string> files)
        {
            this.Name = name;
            this.files = files;
        }
        public void addFile(string fileName)
        {
            files.Add(fileName);
        }
        public string[] getFiles()
        {
            return files.ToArray();
        }
    }
}
