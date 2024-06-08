namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Location;
public class ClientUseBed : IClientPacket
{
    public int EntityId;
    public Position Location;
    public ClientUseBed(int EntityId, Position Location)
    {
        this.EntityId = EntityId;
        this.Location = Location;
    }
    public int GetPacketId() => 0x0A;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WritePosition(Location);

        return buffer;
    }
}