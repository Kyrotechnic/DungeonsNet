namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSetSlot : IClientPacket
{
    public sbyte WindowId;
    public short Slot;
    //TODO: add slot
    public ClientSetSlot()
    {

    }
    public int GetPacketId() => 0x2F;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}