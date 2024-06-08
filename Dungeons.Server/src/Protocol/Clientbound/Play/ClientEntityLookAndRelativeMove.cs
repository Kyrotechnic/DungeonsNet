namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Api;
public class ClientEntityLookAndRelativeMove : IClientPacket
{
    public int EntityId;
    public sbyte DeltaX;
    public sbyte DeltaY;
    public sbyte DeltaZ;
    public Angle Yaw;
    public Angle Pitch;
    public bool OnGround;
    public ClientEntityLookAndRelativeMove(int EntityId, sbyte DeltaX, sbyte DeltaY, sbyte DeltaZ, Angle Yaw, Angle Pitch, bool OnGround)
    {
        this.EntityId = EntityId;
        this.DeltaX = DeltaX;
        this.DeltaY = DeltaY;
        this.DeltaZ = DeltaZ;
        this.Yaw = Yaw;
        this.Pitch = Pitch;
        this.OnGround = OnGround;  
    }
    public int GetPacketId() => 0x17;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(DeltaX);
        buffer.WriteSByte(DeltaY);
        buffer.WriteSByte(DeltaZ);
        buffer.WriteAngle(Yaw);
        buffer.WriteAngle(Pitch);
        buffer.WriteBool(OnGround);

        return buffer;
    }
}