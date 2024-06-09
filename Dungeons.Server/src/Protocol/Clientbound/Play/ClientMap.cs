namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientMap : IClientPacket
{
    //TODO: tmrw
    public ClientMap()
    {

    }
    public int GetPacketId() => 0x34;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}