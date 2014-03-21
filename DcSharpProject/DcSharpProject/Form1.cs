using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DcSharpProject
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        Thread listenThread;

        ServerConnector serverConn;
        ClientConnector clientConn;
        bool listen = true;
        public Form1()
        {
            InitializeComponent();
            serverConn = new ServerConnector();
            clientConn = new ClientConnector();
            this.tcpListener = new TcpListener(IPAddress.Any, 9999); //Creates a TCPlistener that listens for any Ipadress but port 9998.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
            //clientConn.sendCompleteFile(@"C:\Users\Martin\Videos\Inside Zone Techniques.mp4", new Client("127.0.0.1", 9999));
            GetUserData();

            
        }

        public void ListenForClients() //A method that loops aslong as listen is true.
        {
            this.tcpListener.Start(); //starts the tcplistener

            while (listen)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                ////create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        public void HandleClientComm(object client) //This method handels the incoming messages.
        {
            TcpClient tcpClient = (TcpClient)client; //New tcp client
            NetworkStream clientStream = tcpClient.GetStream(); //new networkstream
            MemoryStream stream = new MemoryStream();
            
           
            //If we've been passed an unhelpful initial length, just
            //use 32K.
            byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            int read = 0;
            bool done = false;
            int chunk;
            byte[] output;
            while ((chunk = clientStream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;
                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = clientStream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        done = true;
                        output = buffer;
                        break;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
                //Buffer is now too big. Shrink it.
                output = new byte[read];
                Array.Copy(buffer, output, read);
                //FileStream fileDir = new FileStream(@"C:\asdf.mp4", FileMode.Append);
                //fileDir.Write(output, 0, output.Length);
                //clientStream.CopyTo(fileDir);
                
                
                MemoryStream stream1 = new MemoryStream(output);

                User user = new User("Rickard");
                user.updateDirectoryData(stream1);
                importUserDirtoTreeview(user);
                clientStream.Flush();

                tcpClient.Close();
                break;
            }
        }
        public void clientSendFile(object client)
        {
            
        }
        private byte[] mergeData(byte[] data1, byte[] data2)
        {
            int array1OriginalLength = data1.Length;
            Array.Resize<byte>(ref data1, array1OriginalLength + data2.Length);
            Array.Copy(data2, 0, data1, array1OriginalLength, data2.Length);
            return data1;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Server server = new Server("asdf", "213.100.234.13", 9999, "asdf", "asdf");
            serverConn.loginToServer(server);
        }

        private void GetUserData()
        {

            dirIconList.Images.Add(Image.FromFile(@"usericon.png"));
            dirIconList.Images.Add(Image.FromFile(@"foldericon.png"));
            dirIconList.Images.Add(Image.FromFile(@"pictureicon.png"));
            dirIconList.Images.Add(Image.FromFile(@"movieicon.png"));
            dirIconList.Images.Add(Image.FromFile(@"miscicon.png"));

            Server server = new Server("asdf", "213.100.234.13", 9999, "asdf", "asdf");
            User user = new User("bajs");
            List<Folder> folders = new List<Folder>();
            folders.Add(new Folder("asdf1"));
            folders.Add(new Folder("asdf2"));
            folders[0].addFile("fdsa1.jpg");
            folders[0].addFile("fdsa2.avi");
            folders[1].addFile("fdsa3.exe");
            user.SharedFiles = new Directory(folders);
            if (true == false)
            {
               
            }
            else 
            {
                MemoryStream stream;
                stream = user.getDirectoryData();

                Client client = new Client("127.0.0.1", 9999);
                clientConn.sendUserDirectory(stream, client);


                

            }
        }

        private void importUserDirtoTreeview(User user)
        {
            int nrOfFolders = user.SharedFiles.folders.Count;

            int imageindex;

            TreeNode[] folders = new TreeNode[nrOfFolders];
            for (int i = 0; i < nrOfFolders; i++)
            {
                int nrOfFiles = user.SharedFiles.folders[i].files.Count;
                TreeNode[] tempFolder = new TreeNode[nrOfFiles];
                for (int j = 0; j < nrOfFiles; j++)
                {
                    imageindex = -1;
                    if (user.SharedFiles.folders[i].files[j].EndsWith(".jpg") == true || user.SharedFiles.folders[i].files[j].EndsWith(".jpeg") == true || user.SharedFiles.folders[i].files[j].EndsWith(".bmp") == true || user.SharedFiles.folders[i].files[j].EndsWith(".gif") == true || user.SharedFiles.folders[i].files[j].EndsWith(".png") == true)
                    {
                        imageindex = 2;
                    }
                    else if (user.SharedFiles.folders[i].files[j].EndsWith(".exe") == true)
                    {
                        imageindex = 4;
                    }
                    else if (user.SharedFiles.folders[i].files[j].EndsWith(".avi") == true || user.SharedFiles.folders[i].files[j].EndsWith(".mov") == true || user.SharedFiles.folders[i].files[j].EndsWith(".mp4") == true || user.SharedFiles.folders[i].files[j].EndsWith(".wmv") == true || user.SharedFiles.folders[i].files[j].EndsWith(".flv") == true || user.SharedFiles.folders[i].files[j].EndsWith(".mpg") == true || user.SharedFiles.folders[i].files[j].EndsWith(".mkv") == true)
                    {
                        imageindex = 3;
                    }
                    else
                        imageindex = 3;

                    tempFolder[j] = new TreeNode(user.SharedFiles.folders[i].files[j], imageindex, imageindex);
                }
                folders[i] = new TreeNode(user.SharedFiles.folders[i].Name, 1, 1);
                folders[i].Nodes.AddRange(tempFolder);
            }
            TreeNode userNode = new TreeNode(user.Name, folders);
            userDirTreeView.Nodes.Add(userNode);
        }

    }
}

