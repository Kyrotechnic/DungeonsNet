namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientHeldItemChange : IClientPacket
{
    public sbyte Slot;
    public ClientHeldItemChange(sbyte Slot)
    {
        this.Slot = Slot;   
    }
    public int GetPacketId() => 0x09;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteSByte(Slot);

        return buffer;
    }
}