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

        listener = new(IPAddress.Any, port);
    }

    public void Start()
    {
        listener.Start();

        server.Logger.LogDebug("Started listener. Starting new thread");

        new Thread(async () => {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                
                server.Logger.LogDebug("Connection received!");
                
                server.ConnectionManager.AddUser(new DungeonsUser(client));
            }
        }).Start();
    }
}