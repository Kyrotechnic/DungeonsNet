namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Location;

public class ClientSpawnPosition : IClientPacket
{
    public Position Position;
    public ClientSpawnPosition(Position Position)
    {
        this.Position = Position;
    }
    public int GetPacketId() => 0x05;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WritePosition(Position);

        return buffer;
    }
}