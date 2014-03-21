using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;

namespace DcSharpProject
{
    class ClientConnector
    {
        public void sendFile(string URI, int offset, Client client)
        {
            try
            {
                TcpClient receiverClient = new TcpClient(client.IP, client.Port);
                NetworkStream receiverStream = receiverClient.GetStream();
                byte[] data = File.ReadAllBytes(URI);
                FileStream file = new FileStream(URI, FileMode.Open);
                file.Seek((long)offset, SeekOrigin.Begin);
                file.CopyTo(receiverStream, receiverClient.ReceiveBufferSize);
                //int nrOfSubParts = (data.Length/ receiverClient.ReceiveBufferSize) + 1;
                //int lastPackageSize = data.Length - ((nrOfSubParts - 1) * receiverClient.ReceiveBufferSize);
                //for (int i = 0; i < nrOfSubParts; i++)
                //{
                //    if (i < nrOfSubParts - 1)
                //    {
                //        while (!receiverStream.CanRead) { }
                //        receiverStream.Write(data, i * receiverClient.ReceiveBufferSize, receiverClient.ReceiveBufferSize);
                //        receiverStream.Flush();
                //    }
                //    else
                //    {
                //        while (!receiverStream.CanRead) { }
                //        receiverStream.Write(data, i * receiverClient.ReceiveBufferSize, lastPackageSize);
                //        receiverStream.Flush();
                //    }
                //}               
            }
            catch(SocketException)
            {
                //Lost connection
            }
        }
        //För att kontrollera redan nerladdad data, hasha alla färdiga paket, skicka nycklarna och paketnr till klient. klient svarar med vilka paket som den vill ha
        public void sendPartialFile(string URI, int offset, Client client)
        {
            TcpClient receiverClient = new TcpClient(client.IP, client.Port);
            NetworkStream receiverStream = receiverClient.GetStream();
            byte[] data = File.ReadAllBytes(URI);
            FileStream file = new FileStream(URI, FileMode.Open);
            file.CopyTo(receiverStream);
        }

        public void sendUserDirectory(MemoryStream stream, Client client)
        {
            TcpClient receiverClient = new TcpClient(client.IP, client.Port);
            NetworkStream receiverStream = receiverClient.GetStream();
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(receiverStream, receiverClient.ReceiveBufferSize);
        }
    }
}
