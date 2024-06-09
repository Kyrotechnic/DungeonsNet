namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSpawnGlobalEntity : IClientPacket
{
    public int EntityId;
    public sbyte Type;
    public int X;
    public int Y;
    public int Z;
    public ClientSpawnGlobalEntity(int entityId, sbyte type, int x, int y, int z)
    {
        EntityId = entityId;
        Type = type;
        X = x;
        Y = y;
        Z = z;
    }
    public int GetPacketId() => 0x2C;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(Type);
        buffer.WriteInt(X);
        buffer.WriteInt(Y);
        buffer.WriteInt(Z);

        return buffer;
    }
}