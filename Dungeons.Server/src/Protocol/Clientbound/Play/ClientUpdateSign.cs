using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientUpdateSign : IClientPacket
{
    public Position Location;
    //TODO: added 4 lines of Chat
    public ClientUpdateSign()
    {

    }
    public int GetPacketId() => 0x33;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}