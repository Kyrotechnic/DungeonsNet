namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntity : IClientPacket
{
    public int EntityId;
    public ClientEntity(int EntityId)
    {   
        this.EntityId = EntityId;
    }
    public int GetPacketId() => 0x14;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);

        return buffer;
    }
}