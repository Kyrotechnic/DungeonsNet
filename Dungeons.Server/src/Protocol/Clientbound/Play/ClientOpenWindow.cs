namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientOpenWindow : IClientPacket
{
    public byte WindowId;
    public string WindowType;
    //TODO: Fix it add Chat and figure it out
    public ClientOpenWindow()
    {

    }
    public int GetPacketId() => 0x2D;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}