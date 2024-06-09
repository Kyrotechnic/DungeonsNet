namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientWindowItems : IClientPacket
{
    public byte WindowId;
    public short Count;
    //TODO: add Slot[]
    public ClientWindowItems()
    {

    }
    public int GetPacketId() => 0x30;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}