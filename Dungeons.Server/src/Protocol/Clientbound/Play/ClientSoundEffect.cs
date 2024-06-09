namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSoundEffect : IClientPacket
{
    public string SoundName;
    public int EffectPositionX;
    public int EffectPositionY;
    public int EffectPositionZ;
    public float Volume;
    public byte Pitch;
    public ClientSoundEffect(string soundName, int effectPositionX, int effectPositionY, int effectPositionZ, float volume, byte pitch)
    {
        SoundName = soundName;
        EffectPositionX = effectPositionX;
        EffectPositionY = effectPositionY;
        EffectPositionZ = effectPositionZ;
        Volume = volume;
        Pitch = pitch;
    }
    public int GetPacketId() => 0x29;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteString(SoundName);
        buffer.WriteInt(EffectPositionX);
        buffer.WriteInt(EffectPositionY);
        buffer.WriteInt(EffectPositionZ);
        buffer.WriteFloat(Volume);
        buffer.WriteByte(Pitch);
        
        return buffer;
    }
}