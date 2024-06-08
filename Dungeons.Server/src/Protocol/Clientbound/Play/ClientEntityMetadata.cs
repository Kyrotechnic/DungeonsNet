namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityMetadata : IClientPacket
{
    public int EntityId;
    public byte[] Metadata;

    public ClientEntityMetadata(int EntityId, byte[] Metadata) 
    {
        this.EntityId = EntityId;
        this.Metadata = Metadata;
    }
    public int GetPacketId() => 0x1C;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.Write(Metadata);

        return buffer;
    }
}