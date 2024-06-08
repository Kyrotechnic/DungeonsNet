namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Api;
public class ClientEntityHeadLook : IClientPacket
{
    public int EntityId;
    public Angle HeadYaw;
    public ClientEntityHeadLook(int EntityId, Angle HeadYaw) 
    {
        this.EntityId = EntityId;
        this.HeadYaw = HeadYaw;
    }
    public int GetPacketId() => 0x19;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteAngle(HeadYaw);

        return buffer;
    }
}