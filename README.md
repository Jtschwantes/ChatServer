# ChatServer
This is a C# program that will create a global chat room for anyone with the client who can connect to the server. To set the project up, make sure you can find the code for the client available [here](https://github.com/Jtschwantes/ChatClient).

You will need to run the server somewhere. To do that, you can clone the project file. Ensure that you have the .NET Core runtime on your computer. You will need to edit the IP address and port in the Program.cs file to be the IP address of your computer and the port you want the program to run on. 

You can find that line of code in the line of code shown below:

```C#
    class Program
    {
        private static TcpListener socket = new TcpListener(IPAddress.Parse(/*Here*/"192.168.0.202"), 100);
        // Main execution
        static void Main(string[] args)
        {
            // ...
```

You will need to run `dotnet restore` in the commandline to download the packages needed to run the program, then you should be able to run `dotnet run`. If you see a message saying "Chat server started." you should be good to go.

# Chat client

Head over to the chat client and download the code. 

You will need to change the IP address and port in the client too. You can find that file in the Form1.cs file.

```C#
    // The connect button
    private void button1_Click(object sender, EventArgs e)
    {
        // Return if the client is already connected
        if (server.Connected) 
            return;

        // Try to connect
        try
        {
            server.Connect(IPAddress.Parse(/*Here*/"192.168.0.202"), 100);
        }
        // ...
```

In the bin/Debug folder there should be an application "ChatClient" that you can run. If it doesn't work, try downloading the code except for the bin/ and obj/ folders. Then, open the project in visual studio, and run the project from there. If the server is still running, your application should be able to connect.