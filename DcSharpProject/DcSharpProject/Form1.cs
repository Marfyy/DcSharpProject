﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace DcSharpProject
{
    //Serverport = 9999;
    //Clientlistener = 9000; Alla klienter ska ha en port som alltid lyssnar på inc meddelande från andra klienter
    //ClientFileTransferPortWindow = 9001-9998; När en filöverföring initieras, både upp och ner, ska denna överföringen tilldelas en egen port, dvs en egen listener och tråd
    public partial class Form1 : Form
    {
        User self;
        User selectedUser;
        TcpListener tcpClientListener;
        Thread clientListenThread;
        PortHandler portHandler;
        ServerConnector serverConn;
        ClientConnector clientConn;
        List<Server> connectedServers;

        List<FileUpload> activeUploads;
        List<FileDownload> activeDownloads;
        bool listen = true;
        public Form1()
        {
            InitializeComponent();
            initGUI();
            activeUploads = new List<FileUpload>();
            activeDownloads = new List<FileDownload>();
            XmlDocument xml = new XmlDocument();
            xml.Load(@"userConfig.xml");
            XmlElement root = xml.DocumentElement;
            this.self = new User(root.Attributes["name"].Value.ToString()); 
            Directory selfDir = new Directory();
            XmlNodeList subroot = root.SelectNodes("folder");

            for(int i = 0; i < subroot.Count; i++)
            {
                XmlNode elem = subroot.Item(i);
                Folder folder = new Folder(elem.Attributes["name"].Value.ToString());
                XmlNodeList fileList = elem.SelectNodes("file");
                for(int j = 0; j < fileList.Count; j++)
                {
                    XmlNode fileXML = fileList.Item(j);
                    dirFile file = new dirFile(fileXML.Attributes["name"].Value.ToString(), int.Parse(fileXML.Attributes["size"].Value.ToString()), fileXML.Attributes["intURL"].Value.ToString(), fileXML.Attributes["realURL"].Value.ToString());
                    folder.addFile(file);
                }
                selfDir.addFolder(folder);
            }
            self.SharedFiles = selfDir;
            portHandler = new PortHandler();
            serverConn = new ServerConnector();
            clientConn = new ClientConnector();
            connectedServers = new List<Server>();
            this.tcpClientListener = new TcpListener(IPAddress.Any, portHandler.clientRequestPort); //Creates a TCPlistener that listens for any Ipadress and port 9000.
            this.clientListenThread = new Thread(new ThreadStart(clientRequestListener)); //New thread that will listen for clients.
            this.clientListenThread.IsBackground = true; //Sets the thread to a background process.
            this.clientListenThread.Start(); //Starts the listenerthread.


            //clientConn.sendCompleteFile(@"C:\Users\Martin\Videos\Inside Zone Techniques.mp4", new Client("127.0.0.1", 9999));
            Server server = new Server("bajs", "10.1.1.114", 9999, "markus", "hejsan123");
            //serverConn.loginToServer(server);
            //serverConn.logoutFromServer(server);
            //string response = serverConn.getUserConnInfo(server, "Marreman");
            //BinaryFormatter formatter = new BinaryFormatter();
            //List<string> userNames = serverConn.getCompleteUserListFromServer(server);
            //if (userNames != null)
            //    lstUser.Items.AddRange(userNames.ToArray());
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
        public void clientRequestListener() //A method that loops aslong as listen is true.
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
        public void HandleClientConn(object client) //This method handels the incoming request messages from clients.
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
                string sOutput = Encoding.ASCII.GetString(output);
                if(sOutput.StartsWith("!")) //Request dir info
                {
                    clientConn.sendUserDirectory(self, tcpClient);
                }
                else if(sOutput.StartsWith("@")) //Request file download
                {
                    //receive file request with port
                    //Send ok back with filename, filesize
                    //start sending the file to given port
                    string[] split = sOutput.Split(new char[] { '|' });
                    string fileURL = split[1];
                    int requestedPort = int.Parse(split[2]);
                    dirFile file = self.getFile(fileURL);
                    if(file != null)
                    {
                        Client sendClient = new Client(tcpClient.Client.RemoteEndPoint);
                        sendClient.Port = requestedPort;
                        string message = "OK|"+file.internalURL + "|" + file.sizeMB;
                        clientConn.sendFileDownloadResponse(tcpClient, message); //Send back OK

                        Thread fileTransferThread = new Thread(new ParameterizedThreadStart(clientSendFile));
                        FileUpload upload = new FileUpload(file.internalURL, sendClient);
                        fileTransferThread.Start(upload);
                        
                    }
                }
                break;
            }
        }
        public void clientSendFile(object fileUpload)
        {
            FileUpload upload = (FileUpload)fileUpload;
            activeUploads.Add(upload);
            clientConn.sendFile(upload.fileURL, 0, upload.connectedClient); //Send file
            for(int i = 0; i < activeUploads.Count; i++) //Finds the upload amongst the active ones and marks it done
            {
                if (activeUploads.ElementAt(i).fileURL == upload.fileURL)
                {
                    activeUploads.ElementAt(i).Done();
                    break;
                }
            }
            updateUploadList(); //Updates the upload list with the new status
        }
        public void updateUploadList()
        {
            
        }
        public void updateDownloadList()
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
            //folders[0].addFile("fdsa1.jpg");
            //folders[0].addFile("fdsa2.avi");
            //folders[1].addFile("fdsa3.exe");
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
                    if (user.SharedFiles.folders[i].files[j].Name.EndsWith(".jpg") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".jpeg") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".bmp") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".gif") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".png") == true)
                    {
                        imageindex = 2;
                    }
                    else if (user.SharedFiles.folders[i].files[j].Name.EndsWith(".exe") == true)
                    {
                        imageindex = 4;
                    }
                    else if (user.SharedFiles.folders[i].files[j].Name.EndsWith(".avi") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".mov") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".mp4") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".wmv") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".flv") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".mpg") == true || user.SharedFiles.folders[i].files[j].Name.EndsWith(".mkv") == true)
                    {
                        imageindex = 3;
                    }
                    else
                        imageindex = 3;

                    tempFolder[j] = new TreeNode(user.SharedFiles.folders[i].files[j].Name, imageindex, imageindex);
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
            if (serverResponse.StartsWith("@OK"))
            {
                string[] split = serverResponse.Split(new char[] { '|' });
                clientToConnect = new Client(split[1], int.Parse(split[2]));
                NetworkStream clientRequestResponse = clientConn.sendDirectoryRequest(clientToConnect);
                if(clientRequestResponse != null)
                {
                    selectedUser = new User(lstUser.SelectedItem.ToString());
                    MemoryStream stream = new MemoryStream();
                    clientRequestResponse.CopyTo(stream);
                    selectedUser.updateDirectoryData(stream);
                }
            }
            else if (serverResponse.StartsWith("@NOK"))
                MessageBox.Show("That user does not exist");
            else
            {
                MessageBox.Show("Connection failed");
            }
        }
        private void userDirTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (userDirTreeView.SelectedNode.Nodes.Count == 0) //Selected item is a file and not a folder or user
            {
                string url = userDirTreeView.SelectedNode.Parent.Text + "\\" + userDirTreeView.SelectedNode.Text;
                string userName = (string)lstUser.SelectedItem;
                string serverResponse = serverConn.getUserConnInfo(connectedServers[cmbServer.SelectedIndex], userName);
                Client clientToConnect;
                int port = portHandler.getPort();
                if (serverResponse.StartsWith("@OK"))
                {
                    string[] split = serverResponse.Split(new char[] { '|' });
                    clientToConnect = new Client(split[1], int.Parse(split[2]));
                    string clientRequestResponse = clientConn.sendFileDownloadRequest(clientToConnect, url, port);
                    if (clientRequestResponse.CompareTo("Connection failed") != 0)
                    {
                        if(clientRequestResponse.StartsWith("%OK")) //Confirms that other user accepted the download request
                        {
                            split = clientRequestResponse.Split(new char[] { '|' });
                            FileDownload download = new FileDownload();
                            download.file.internalURL = split[1];
                            download.file.sizeMB = int.Parse(split[2]);
                        }
                    }

                    portHandler.recyclePort(port);
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
}

