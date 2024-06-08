
namespace Dungeons.Server.Protocol.Clientbound.Play;
using Dungeons.Server.Api;

public class ClientSpawnPlayer : IClientPacket
{
    public int EntityId;
    public Guid UUID;
    public double X;
    public double Y;
    public double Z;
    public Angle Yaw;
    public Angle Pitch;
    public short CurrentItem;
    public byte[] Metadata;
    public ClientSpawnPlayer(int EntityId, Guid UUID, double X, double Y, double Z, float Yaw, float Pitch, short CurrentItem, byte[] Metadata)
    {
        this.EntityId = EntityId;
        this.UUID = UUID;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.Yaw = Yaw;
        this.Pitch = Pitch;
        this.CurrentItem = CurrentItem;
        this.Metadata = Metadata;
    }
    public int GetPacketId() => 0x0C;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteGuid(UUID);
        buffer.WriteDouble(X);
        buffer.WriteDouble(Y);
        buffer.WriteDouble(Z);
        buffer.WriteAngle(Yaw);
        buffer.WriteAngle(Pitch);
        buffer.WriteShort(CurrentItem);
        buffer.Write(Metadata);

        return buffer;
    }
}