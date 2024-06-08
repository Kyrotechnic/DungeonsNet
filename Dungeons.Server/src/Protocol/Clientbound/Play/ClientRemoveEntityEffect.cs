namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientRemoveEntityEffect : IClientPacket
{
    public int EntityId;
    public sbyte EffectId;
    public ClientRemoveEntityEffect(int EntityId, sbyte EffectId) 
    {
        this.EntityId = EntityId;
        this.EffectId = EffectId;
    }
    public int GetPacketId() => 0x1E;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(EffectId);

        return buffer;
    }
}