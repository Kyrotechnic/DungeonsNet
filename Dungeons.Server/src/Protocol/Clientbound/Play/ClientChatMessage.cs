namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientChatMessage : IClientPacket
{
    //TODO: Add FieldName = JSON Data FieldType = Chat
    public byte Position;
    public ClientChatMessage(byte Position)
    {
        this.Position = Position;
    }
    public int GetPacketId() => 0x02;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteByte(Position);

        return buffer;
    }
}