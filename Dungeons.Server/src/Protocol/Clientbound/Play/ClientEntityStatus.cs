namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityStatus : IClientPacket
{
    public int EntityId;
    public sbyte EntityStatus;
    public ClientEntityStatus(int EntityId, sbyte EntityStatus)
    {
        this.EntityId = EntityId;
        this.EntityStatus = EntityStatus;
    }
    public int GetPacketId() => 0x1A;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(EntityStatus);

        return buffer;
    }
}