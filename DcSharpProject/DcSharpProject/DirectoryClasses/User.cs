using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    class User
    {
        public string Name { get; private set; }
        public Directory SharedFiles { get; private set; }
        public User(string name)
        {
            this.Name = name;
            this.SharedFiles = new Directory();
        }
        public User(string name, Directory sharedFiles)
        {
            this.Name = name;
            this.SharedFiles = sharedFiles;
        }
        public void updateDirectoryData(string rawDirData)
        {
            SharedFiles.folders.Add(new Folder("bajs"));
            SharedFiles.folders[0].files.Add("bajs1.jpg");
            SharedFiles.folders[0].files.Add("bajs2.avi");
            SharedFiles.folders[0].files.Add("bajs3.exe");
        }
    }
}
