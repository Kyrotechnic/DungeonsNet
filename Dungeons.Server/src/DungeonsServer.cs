using Dungeons.Server.Api;
using Dungeons.Server.Config;
using Dungeons.Server.Logger;
using Dungeons.Server.Managers;
using Dungeons.Server.Network;

namespace Dungeons.Server;

public class DungeonsServer
{
    public ServerData ServerData {get; private set;}
    public ConnectionManager ConnectionManager {get; private set;}
    public ConfigReader Config {get; private set;}
    public DungeonsLogger Logger {get; private set;}
    public Listener Listener {get; private set;}
    public DungeonsServer(string configPath = "config.meow")
    {
        ServerInstance.server = this;
        
        Config = new(configPath);
        Logger = new(Config.Get("logger.name", "server"), true);
        Listener = new();
        
        int port = Config.Get("server.port", 25565);

        ServerData = new(port, true);
        ConnectionManager = new();

        Listener.Start();
        Logger.LogDebug("Started listener on port " + ServerData.port + ". Waiting for connections.");

        while (true);
    }
}