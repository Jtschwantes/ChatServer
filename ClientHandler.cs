using System;
// For the networking
using System.Net.Sockets;
// For multithreading
using System.Threading.Tasks;
// For colorful console text
using static Prysm.Pym;
using static Prysm.Colors;

namespace ChatServer
{
    internal partial class ClientHandler
    {
        // Private fields
        private TcpClient client;
        private string name;
        // Constructor
        internal ClientHandler(TcpClient client, string name)
        {
            // Initialize variables
            this.client = client;
            this.name = name;
            // Start independant task
            Task task = new Task(doChat);
            task.Start();
        }
        // Handles messages from the client
        private void doChat()
        {
            while(true)
            {
                try
                {
                    // Get and format message from client
                    string message = Globals.ReadFromClient(client);
                    message = $"[{DateTime.Now.ToShortTimeString()}] {name} said: {message}";

                    // Publicize message
                    Globals.Publish(message); // To clients
                    Gradient(message, Red, Yellow); // To server log
                }
                catch
                {
                    // If something goes wrong, remove client and quit
                    Globals.clients.Remove(name);
                    return;
                }
            }
        }
    }
}