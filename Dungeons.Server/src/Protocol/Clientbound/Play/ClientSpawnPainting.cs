namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Location;
public class ClientSpawnPainting : IClientPacket
{
    public int EntityId;
    public string Title;
    public Position Location;
    public byte Direction;
    public ClientSpawnPainting(int EntityId, string Title, Position Location, byte Direction)
    {
        this.EntityId = EntityId;
        this.Title = Title;
        this.Location = Location;
        this.Direction = Direction;
    }
    public int GetPacketId() => 0x10;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteString(Title);
        buffer.WritePosition(Location);
        buffer.WriteByte(Direction);

        return buffer;
    }
}