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
    //Serverport = 9999;
    //Clientlistener = 9000; Alla klienter ska ha en port som alltid lyssnar på inc meddelande från andra klienter
    //ClientFileTransferPortWindow = 9001-9998; När en filöverföring initieras, både upp och ner, ska denna överföringen tilldelas en egen port, dvs en egen listener och tråd
    public partial class Form1 : Form
    {
        TcpListener tcpClientListener;
        Thread clientListenThread;

        ServerConnector serverConn;
        ClientConnector clientConn;
        List<Server> connectedServers;
        bool listen = true;
        public Form1()
        {
            InitializeComponent();
            initGUI();
            serverConn = new ServerConnector();
            clientConn = new ClientConnector();
            connectedServers = new List<Server>();
            this.tcpClientListener = new TcpListener(IPAddress.Any, 9000); //Creates a TCPlistener that listens for any Ipadress and port 9000.
            this.clientListenThread = new Thread(new ThreadStart(clientListener)); //New thread that will listen for clients.
            this.clientListenThread.IsBackground = true; //Sets the thread to a background process.
            this.clientListenThread.Start(); //Starts the listenerthread.
            //clientConn.sendCompleteFile(@"C:\Users\Martin\Videos\Inside Zone Techniques.mp4", new Client("127.0.0.1", 9999));
            Server server = new Server("bajs", "10.1.1.114", 9999, "markus", "hejsan123");
            serverConn.getCompleteUserListFromServer(server);
        }
        public void initGUI()
        {
            dirIconList.Images.Add(Image.FromFile(@"icons\usericon.png"));
            dirIconList.Images.Add(Image.FromFile(@"icons\foldericon.png"));
            dirIconList.Images.Add(Image.FromFile(@"icons\pictureicon.png"));
            dirIconList.Images.Add(Image.FromFile(@"icons\movieicon.png"));
            dirIconList.Images.Add(Image.FromFile(@"icons\miscicon.png"));
        }
        /// <summary>
        /// This method runs always, to catch any messages that another client sends to you. For example request for user dir, request for start download
        /// </summary>
        public void clientListener() //A method that loops aslong as listen is true.
        {
            this.tcpClientListener.Start(); //starts the tcplistener

            while (listen)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpClientListener.AcceptTcpClient();
                ////create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientConn));
                clientThread.Start(client);
            }
        }
        public void startClientListener(Client client, int clientPort, int transferID)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse(client.IP), clientPort);
            listener.Start();

            TcpClient remoteClient = listener.AcceptTcpClient();
            Thread clientThread;
            if (transferID == 0) //directory information download
            {
                clientThread = new Thread(new ParameterizedThreadStart(HandleUserDirectoryData));
                clientThread.Start(remoteClient);
            }
            else if(transferID == 1) //file download
            {
                clientThread = new Thread(new ParameterizedThreadStart(HandleFileDownloadData));
                clientThread.Start(remoteClient);
            }
        }
        public void HandleUserDirectoryData(object client)
        {
            TcpClient tcpClient = (TcpClient)client; //New tcp client
            NetworkStream clientStream = tcpClient.GetStream(); //new networkstream
            MemoryStream stream = new MemoryStream();
            clientStream.CopyTo(stream);
            connectedServers[cmbServer.SelectedIndex].users[lstUser.SelectedIndex].updateDirectoryData(stream);
            importUserDirtoTreeview(connectedServers[cmbServer.SelectedIndex].users[lstUser.SelectedIndex]);

            ////If we've been passed an unhelpful initial length, just
            ////use 32K.
            //byte[] buffer = new byte[tcpClient.ReceiveBufferSize];
            //int read = 0;
            //bool done = false;
            //int chunk;
            //byte[] output;
            //string message;
            //while ((chunk = clientStream.Read(buffer, read, buffer.Length - read)) > 0)
            //{
            //    read += chunk;
            //    // If we've reached the end of our buffer, check to see if there's
            //    // any more information
            //    if (read == buffer.Length)
            //    {
            //        int nextByte = clientStream.ReadByte();

            //        // End of stream? If so, we're done
            //        if (nextByte == -1)
            //        {
            //            done = true;
            //            output = buffer;
            //            break;
            //        }

            //        // Nope. Resize the buffer, put in the byte we've just
            //        // read, and continue
            //        byte[] newBuffer = new byte[buffer.Length * 2];
            //        Array.Copy(buffer, newBuffer, buffer.Length);
            //        newBuffer[read] = (byte)nextByte;
            //        buffer = newBuffer;
            //        read++;
            //    }
            //    //Buffer is now too big. Shrink it.
            //    output = new byte[read];
            //    Array.Copy(buffer, output, read);
            //    message = Encoding.Default.GetString(output);

            //    tcpClient.Close();
            //    break;
            //}
            //if(message != null)
            //{
                
            //}
        }
        public void HandleFileDownloadData(object client)
        {
            
        }
        public void HandleClientConn(object client) //This method handels the incoming messages.
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


                tcpClient.Close();
                break;
            }
        }
        public void clientSendFile(object client)
        {
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Server server = new Server("asdf", "213.100.234.13", 9999, "asdf", "asdf");
            string serverMessage = serverConn.loginToServer(server);
        }
        /// <summary>
        /// tempuser
        /// </summary>
        private User CreateTempUser()
        {
            //Treeview icons
            

            //Creates temporary user with a made up filestructure
            User user = new User("bajs");
            List<Folder> folders = new List<Folder>();
            folders.Add(new Folder("asdf1"));
            folders.Add(new Folder("asdf2"));
            folders[0].addFile("fdsa1.jpg");
            folders[0].addFile("fdsa2.avi");
            folders[1].addFile("fdsa3.exe");
            user.SharedFiles = new Directory(folders);
            return user;
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

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userName = (string)lstUser.SelectedItem;
            string serverResponse = serverConn.getUserConnInfo(connectedServers[cmbServer.SelectedIndex], userName);
            Client clientToConnect;
            int listenerPort;
            if (serverResponse.StartsWith("@OK"))
            {
                string[] split = serverResponse.Split(new char[] { ' ' });
                clientToConnect = new Client(split[1], int.Parse(split[2]));
                string clientRequestResponse = clientConn.sendDirectoryRequest(clientToConnect);
                if(clientRequestResponse.StartsWith("@OK"))
                {
                    split = clientRequestResponse.Split(new char[] { ' ' });
                    listenerPort = int.Parse(split[1]);
                    startClientListener(clientToConnect, listenerPort, 0);
                }
            }
            else if (serverResponse.StartsWith("@NOK"))
                MessageBox.Show("That user does not exist");
            else
            {
                MessageBox.Show("Connection failed");
            }
        } 
    }
}

