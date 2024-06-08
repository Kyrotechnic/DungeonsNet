namespace Dungeons.Server.Protocol.Clientbound.Play;

public class EntityRelativeMove : IClientPacket
{
    public int EntityId;
    public sbyte DeltaX;
    public sbyte DeltaY;
    public sbyte DeltaZ;
    public bool OnGround;
    public EntityRelativeMove(int EntityId, sbyte DeltaX, sbyte DeltaY, sbyte DeltaZ, bool OnGround) 
    {
        this.EntityId = EntityId;
        this.DeltaX = DeltaX;
        this.DeltaY = DeltaY;
        this.DeltaZ = DeltaZ;
        this.OnGround = OnGround;
    }
    public int GetPacketId() => 0x15;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(DeltaX);
        buffer.WriteSByte(DeltaY);
        buffer.WriteSByte(DeltaZ);
        buffer.WriteBool(OnGround);
        
        return buffer;
    }
}