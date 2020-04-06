// For the dictionary
using System.Collections.Generic;
// For the networking
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{    
    using TcpDict = Dictionary<string, TcpClient>;
    internal static class Globals
    {
        internal static TcpDict clients = new TcpDict();
        private static byte[] buffer = new byte[8192];
        // Reads a message from the client
        internal static string ReadFromClient(TcpClient client)
        {
            NetworkStream networkStream = client.GetStream();
            networkStream.Read(buffer, 0, buffer.Length);
            var rawName = Encoding.ASCII.GetString(buffer);
            var name = rawName.Substring(0, rawName.IndexOf("%^&"));
            return name;
        }
        // Publishes new messages to all clients in the chat
        internal static void Publish(string rawMsg)
        {
            foreach(var client in clients)
            {
                NetworkStream stream = ((TcpClient)client.Value).GetStream();
                var msg = Encoding.ASCII.GetBytes(rawMsg);
                stream.Write(msg, 0, msg.Length);
                stream.Flush();
            }
        }
    }
}