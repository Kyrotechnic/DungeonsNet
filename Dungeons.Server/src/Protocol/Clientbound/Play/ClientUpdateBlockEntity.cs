using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientUpdateBlockEntity : IClientPacket
{
    public Position Location;
    public byte Action;
    //TODO: add NBT Data
    public ClientUpdateBlockEntity()
    {

    }
    public int GetPacketId() => 0x35;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}