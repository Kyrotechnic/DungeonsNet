namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientExplosion : IClientPacket
{
    public float X;
    public float Y;
    public float Z;
    public float Radius;
    public ExplosionRecord[] Records;
    public float PlayerMotionX;
    public float PlayerMotionY;
    public float PlayerMotionZ;
    public ClientExplosion(float x, float y, float z, float radius, ExplosionRecord[] records, float playerMotionX, float playerMotionY, float playerMotionZ)
    {
        X = x;
        Y = y;
        Z = z;
        Radius = radius;
        Records = records;
        PlayerMotionX = playerMotionX;
        PlayerMotionY = playerMotionY;
        PlayerMotionZ = playerMotionZ;
    }
    public int GetPacketId() => 0x27;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteFloat(X);
        buffer.WriteFloat(Y);
        buffer.WriteFloat(Z);
        buffer.WriteFloat(Radius);
        buffer.WriteInt(Records.Length);
        
        for (int i = 0; i < Records.Length; i++) {
            ExplosionRecord current = Records[i];

            buffer.WriteSByte(current.Byte1);
            buffer.WriteSByte(current.Byte2);
            buffer.WriteSByte(current.Byte3);
        }

        buffer.WriteFloat(PlayerMotionX);
        buffer.WriteFloat(PlayerMotionY);
        buffer.WriteFloat(PlayerMotionZ);

        return buffer;
    }
}