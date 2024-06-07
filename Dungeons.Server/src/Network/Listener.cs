using System.Net;
using System.Net.Sockets;
using Dungeons.Server.Api;
using Dungeons.Server.Managers;
using Dungeons.Server.User;

namespace Dungeons.Server.Network;

public class Listener : ServerInstance
{
    private TcpListener listener;
    public Listener()
    {
        int port = server.ServerData.port;

        Console.WriteLine("port is " + port);

        listener = new(IPAddress.Any, port);
    }

    public void Start()
    {
        server.Logger.LogDebug("Started listener. Starting new thread");

        new Thread(() => {
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                server.Logger.LogDebug("Found client finally holy hsit wht f");

                server.ConnectionManager.AddUser(new(client));
            }
        }).Start();
    }
}