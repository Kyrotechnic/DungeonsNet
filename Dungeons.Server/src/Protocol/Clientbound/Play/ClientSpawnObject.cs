namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Api;

public class ClientSpawnObject : IClientPacket
{
    public int EntityId;
    public sbyte Type;
    public int X;
    public int Y;
    public int Z;
    public Angle Pitch;
    public Angle Yaw;
    public int Data;
    public short VelocityX;
    public short VelocityY;
    public short VelocityZ;
    public ClientSpawnObject(int EntityId, sbyte Type, int X, int Y, int Z, Angle Yaw, Angle Pitch, int Data, short VelocityX, short VelocityY, short VelocityZ) 
    {
        this.EntityId = EntityId;
        this.Type = Type;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.Pitch = Pitch;
        this.Yaw = Yaw;
        this.Data = Data;
        this.VelocityX = VelocityX;
        this.VelocityY = VelocityY;
        this.VelocityZ = VelocityZ;
    }
    public int GetPacketId() => 0x0E;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(Type);
        buffer.WriteInt(X);
        buffer.WriteInt(Y);
        buffer.WriteInt(Z);
        buffer.WriteAngle(Pitch);
        buffer.WriteAngle(Yaw);
        buffer.WriteInt(Data);
        buffer.WriteShort(VelocityX);
        buffer.WriteShort(VelocityY);
        buffer.WriteShort(VelocityZ);

        return buffer;
    }
}