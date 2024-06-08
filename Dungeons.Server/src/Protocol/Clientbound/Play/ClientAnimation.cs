namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientAnimation : IClientPacket
{
    public int EntityId;
    public byte Animation;
    public ClientAnimation(int EntityId, byte Animation)
    {
        this.EntityId = EntityId;
        this.Animation = Animation;
    }
    public int GetPacketId() => 0x0B;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteByte(Animation);

        return buffer;
    }
}