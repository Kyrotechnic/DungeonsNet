namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientCloseWindow : IClientPacket
{
    public byte WindowId;
    public ClientCloseWindow(byte windowId)
    {
        WindowId = windowId;
    }
    public int GetPacketId() => 0x2E;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteByte(WindowId);        

        return buffer;
    }
}