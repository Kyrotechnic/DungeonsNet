namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityVelocity : IClientPacket
{
    
    public ClientEntityVelocity()
    {

    }
    public int GetPacketId() => 0x12;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}