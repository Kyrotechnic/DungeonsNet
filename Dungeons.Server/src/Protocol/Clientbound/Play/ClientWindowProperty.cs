namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientWindowProperty : IClientPacket
{
    public byte WindowId;
    public short Property;
    public short Value;
    public ClientWindowProperty(byte windowId, short property, short value)
    {
        WindowId = windowId;
        Property = property;
        Value = value;
    }
    public int GetPacketId() => 0x31;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteByte(WindowId);
        buffer.WriteShort(Property);
        buffer.WriteShort(Value);

        return buffer;
    }
}