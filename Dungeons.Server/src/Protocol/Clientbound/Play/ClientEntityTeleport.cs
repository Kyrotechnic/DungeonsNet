using System.Runtime.CompilerServices;
using Dungeons.Server.Api;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityTeleport : IClientPacket
{
    public int EntityId;
    public int X;
    public int Y;
    public int Z;
    public Angle Yaw;
    public Angle Pitch;
    public bool OnGround;
    public ClientEntityTeleport(int EntityId, int X, int Y, int Z, Angle Yaw, Angle Pitch, bool OnGround)
    {
        this.EntityId = EntityId;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.Yaw = Yaw;
        this.Pitch = Pitch;
        this.OnGround = OnGround;
    }
    public int GetPacketId() => 0x18;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteInt(X);
        buffer.WriteInt(Y);
        buffer.WriteInt(Z);
        buffer.WriteAngle(Yaw);
        buffer.WriteAngle(Pitch);
        buffer.WriteBool(OnGround);

        return buffer;
    }
}