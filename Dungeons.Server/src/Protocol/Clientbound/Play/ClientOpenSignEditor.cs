using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientOpenSignEditor : IClientPacket
{
    public Position Location;
    public ClientOpenSignEditor(Position location)
    {
        Location = location;
    }
    public int GetPacketId() => 0x36;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WritePosition(Location);

        return buffer;
    }
}