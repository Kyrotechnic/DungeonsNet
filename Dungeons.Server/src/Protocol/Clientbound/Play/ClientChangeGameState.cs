namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientChangeGameState : IClientPacket
{
    public byte Reason;
    public float Value;
    public ClientChangeGameState(byte reason, float value)
    {
        Reason = reason;
        Value = value;
    }
    public int GetPacketId() => 0x2B;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteByte(Reason);
        buffer.WriteFloat(Value);

        return buffer;
    }
}