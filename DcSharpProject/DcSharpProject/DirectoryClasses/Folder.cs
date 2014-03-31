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
        public List<dirFile> files;
        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<dirFile>();
        }
        public Folder(string name, List<dirFile> files)
        {
            this.Name = name;
            this.files = files;
        }
        public void addFile(dirFile file)
        {
            files.Add(file);
        }
        public dirFile[] getFiles()
        {
            return files.ToArray();
        }
    }
}
