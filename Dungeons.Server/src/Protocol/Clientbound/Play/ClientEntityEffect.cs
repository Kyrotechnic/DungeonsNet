namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityEffect : IClientPacket
{
    public int EntityId;
    public sbyte EffectId;
    public sbyte Amplifier;
    public int Duration;
    public bool HideParticles;
    public ClientEntityEffect(int EntityId, sbyte EffectId, sbyte Amplifier, int Duration, bool HideParticles)
    {
        this.EntityId = EntityId;
        this.EffectId = EffectId;
        this.Amplifier = Amplifier; 
        this.Duration = Duration;
        this.HideParticles = HideParticles;
    }
    public int GetPacketId() => 0x1D;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(EntityId);
        buffer.WriteSByte(EffectId);
        buffer.WriteSByte(Amplifier);
        buffer.WriteVarInt(Duration);
        buffer.WriteBool(HideParticles);

        return buffer;
    }
}