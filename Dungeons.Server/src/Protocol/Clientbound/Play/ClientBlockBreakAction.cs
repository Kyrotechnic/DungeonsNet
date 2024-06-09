using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientBlockBreakAction : IClientPacket
{
    public int EntityId;
    public Position Location;
    public sbyte DestroyStage;
    public ClientBlockBreakAction(int EntityId, Position Location, sbyte DestroyStage)
    {
        this.EntityId = EntityId;
        this.Location = Location;
        this.DestroyStage = DestroyStage;
    }
    public int GetPacketId() => 0x25;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WritePosition(Location);
        buffer.WriteSByte(DestroyStage);

        return buffer;
    }
}