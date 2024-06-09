namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityEquipment : IClientPacket
{
    public int EntityId;
    public short Slot;
    //TODO: SLOT
    public ClientEntityEquipment(int EntityId, short Slot)
    {
        this.EntityId = EntityId;
        this.Slot = Slot;
    }
    public int GetPacketId() => 0x04;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteShort(Slot);
        

        return buffer;
    }
}