namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientParticle : IClientPacket
{
    public int ParticleId;
    public bool LongDistance;
    public float X;
    public float Y;
    public float Z;
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;
    public float ParticleData;
    public int[] Data;
    public ClientParticle(int particleId, bool longDistance, float x, float y, float z, float offsetX, float offsetY, float offsetZ, float particleData, int[] data)
    {
        ParticleId = particleId;
        LongDistance = longDistance;
        X = x;
        Y = y;
        Z = z;
        OffsetX = offsetX;
        OffsetY = offsetY;
        OffsetZ = offsetZ;
        ParticleData = particleData;
        Data = data;
    }
    public int GetPacketId() => 0x2A;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(ParticleId);
        buffer.WriteBool(LongDistance);
        buffer.WriteFloat(X);
        buffer.WriteFloat(Y);
        buffer.WriteFloat(Z);
        buffer.WriteFloat(OffsetX);
        buffer.WriteFloat(OffsetY);
        buffer.WriteFloat(OffsetZ);
        buffer.WriteFloat(ParticleData);
        buffer.WriteInt(Data.Length);

        for (int i = 0; i < Data.Length; i++) {
            buffer.WriteVarInt(Data[i]);
        }

        return buffer;
    }
}