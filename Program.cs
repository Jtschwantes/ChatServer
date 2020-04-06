using System;
// For Networking
using System.Net.Sockets;
using System.Net;
// For colorful console text
using static Prysm.Pym;
using static Prysm.Colors;

namespace ChatServer
{
    class Program
    {
        // Private fields
        private static TcpListener socket = new TcpListener(IPAddress.Parse("192.168.0.202"), 100);
        // Main execution
        static void Main(string[] args)
        {
            Initialize(); // Prysm, the cool colors and stuff

            // Start server!
            socket.Start();
            Gradient("Chat Server Started.", Magenta, Cyan); // To Console

            // Listen for clients
            while(true)
            {
                // Wait for new client
                TcpClient clientSocket = socket.AcceptTcpClient();
                Gradient("New Client Accepted!", Cyan, Green);

                // Read name from user
                string name = Globals.ReadFromClient(clientSocket);
                // Add to our list
                Globals.clients.Add(name, clientSocket);

                // Publicize message
                string message = $"[{DateTime.Now.ToShortTimeString()}] {name} joined the chat!";
                Globals.Publish(message); // To clients
                Gradient(message, Yellow, Green); // To server log

                // Start new client self-handler
                new ClientHandler(clientSocket, name);
            }
        }
    }
}