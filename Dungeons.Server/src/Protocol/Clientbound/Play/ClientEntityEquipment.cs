namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityEquipment : IClientPacket
{
    public int EntityId;
    public short slot;
    //TODO: 
    public ClientEntityEquipment()
    {

    }
    public int GetPacketId() => 0x04;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}