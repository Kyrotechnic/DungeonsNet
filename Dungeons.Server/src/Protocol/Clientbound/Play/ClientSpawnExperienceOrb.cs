namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSpawnExperienceOrb : IClientPacket
{
    public int EntityId;
    public int X;
    public int Y;
    public int Z;
    public short Count;
    public ClientSpawnExperienceOrb(int EntityId, int X, int Y, int Z, short Count) {
        this.EntityId = EntityId;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.Count = Count;
    }
    public int GetPacketId() => 0x11;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteInt(X);
        buffer.WriteInt(Y);
        buffer.WriteInt(Z);
        buffer.WriteShort(Count);

        return buffer;
    }
}