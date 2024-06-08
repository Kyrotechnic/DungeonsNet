using System.Security.Cryptography.X509Certificates;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSpawnMob : IClientPacket
{
    public int EntityId;
    public byte Type;
    public int X;
    public int Y;
    public int Z;
    //public Angle Yaw;
    //public Angle Pitch;
    //public Angle HeadPitch
    public short VelocityX;
    public short VelocityY;
    public short VelocityZ;
    //public Metadata Metadata;
    public ClientSpawnMob(int EntityId, byte Type, int X, int Y, int Z, /*Angle Yaw, Angle Pitch, Angle HeadPitch, */ short VelocityX, short VelocityY, short VelocityZ/*, Metadata Metadata*/)
    {
        this.EntityId = EntityId;
        this.Type = Type;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        //this.Yaw = Yaw;
        //this.Pitch = Pitch;
        //this.HeadPitch = HeadPitch;
        this.VelocityX = VelocityX;
        this.VelocityY = VelocityY;
        this.VelocityZ = VelocityZ;
        //this.Metadata = metadata
    }
    public int GetPacketId() => 0x0F;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteByte(Type);
        buffer.WriteInt(X);
        buffer.WriteInt(Y);
        buffer.WriteInt(Z);
        //uh idk
        buffer.WriteShort(VelocityX);
        buffer.WriteShort(VelocityY);
        buffer.WriteShort(VelocityZ);
        //meow :3
        return buffer;
    }
}