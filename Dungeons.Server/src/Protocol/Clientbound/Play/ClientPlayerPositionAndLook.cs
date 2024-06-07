namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientPlayerPositionAndLock : IClientPacket
{
    public double X;
    public double Y;
    public double Z;
    public float Yaw;
    public float Pitch;
    public sbyte Flags;
    public ClientPlayerPositionAndLock(double X, double Y, double Z, float Yaw, float Pitch, sbyte Flags)
    {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
        this.Yaw = Yaw;
        this.Pitch = Pitch;
        this.Flags = Flags;
    }
    public int GetPacketId() => 0x08;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteDouble(X);
        buffer.WriteDouble(Y);
        buffer.WriteDouble(Z);
        buffer.WriteFloat(Yaw);
        buffer.WriteFloat(Pitch);
        buffer.WriteSByte(Flags);

        return buffer;
    }
}