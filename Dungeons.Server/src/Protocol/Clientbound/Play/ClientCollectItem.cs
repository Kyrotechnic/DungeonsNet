namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientCollectItem : IClientPacket
{
    public int CollectedEntityId;
    public int CollectorEntityId;
    public ClientCollectItem(int CollectedEntityId, int CollectorEntityId)
    {
        this.CollectedEntityId = CollectedEntityId;
        this.CollectorEntityId = CollectorEntityId;
    }
    public int GetPacketId() => 0x0D;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(CollectedEntityId);
        buffer.WriteVarInt(CollectorEntityId);

        return buffer;
    }
}