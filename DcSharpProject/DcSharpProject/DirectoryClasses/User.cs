using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DcSharpProject
{
    
    class User
    {
        public string Name { get; private set; }
        public Directory SharedFiles { get; set; }
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

        public void updateDirectoryData(MemoryStream rawDirData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            rawDirData.Seek(0, SeekOrigin.Begin);
            SharedFiles = (Directory)formatter.Deserialize(rawDirData);
        }

        public MemoryStream getDirectoryData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, SharedFiles);

            return stream;

        }


    }
}
