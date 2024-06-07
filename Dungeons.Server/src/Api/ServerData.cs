namespace Dungeons.Server.Api;

public struct ServerData
{
    public int port;
    public bool compression;
    public ServerData(int port, bool compression)
    {
        this.port = port;
        this.compression = compression;
    }
}