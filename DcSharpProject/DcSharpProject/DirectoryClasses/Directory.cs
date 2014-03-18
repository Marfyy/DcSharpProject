using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class Directory
    {
        public List<Folder> folders;
        public Directory()
        {
            folders = new List<Folder>();
        }
        public Directory(List<Folder> folders)
        {
            this.folders = folders;
        }
        public Folder[] getFolders()
        {
            return folders.ToArray();
        }
    }
}
