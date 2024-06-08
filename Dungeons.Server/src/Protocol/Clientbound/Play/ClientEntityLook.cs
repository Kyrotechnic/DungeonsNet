namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Api;

public class ClientEntityLook : IClientPacket
{
    public int EntityId;
    public Angle Yaw;
    public Angle Pitch;
    public bool OnGround;
    public ClientEntityLook(int EntityId, Angle Yaw, Angle Pitch, bool OnGround)
    {   
        this.EntityId = EntityId;
        this.Yaw = Yaw;
        this.Pitch = Pitch;
        this.OnGround = OnGround;
    }
    public int GetPacketId() => 0x16;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteAngle(Yaw);
        buffer.WriteAngle(Pitch);
        buffer.WriteBool(OnGround);

        return buffer;
    }
}