namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientConfirmTransaction : IClientPacket
{
    public sbyte WindowId;
    public short ActionNumber;
    public bool Accepted;
    public ClientConfirmTransaction(sbyte windowId, short actionNumber, bool accepted)
    {
        WindowId = windowId;
        ActionNumber = actionNumber;
        Accepted = accepted;
    }
    public int GetPacketId() => 0x32;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteSByte(WindowId);
        buffer.WriteShort(ActionNumber);
        buffer.WriteBool(Accepted);

        return buffer;
    }
}