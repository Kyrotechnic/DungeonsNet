namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientDestroyEntities : IClientPacket
{
    public int Count;
    public int[] EntityIds;
    public ClientDestroyEntities(int Count, int[] EntityIds) 
    {
        this.Count = Count;
        this.EntityIds = EntityIds;
    }
    
    public int GetPacketId() => 0x13;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(Count);
        
        buffer.WriteVarInt(EntityIds.Length);

        foreach (int i in EntityIds) {
            buffer.WriteVarInt(i);
        }
        

        return buffer;
    }
}