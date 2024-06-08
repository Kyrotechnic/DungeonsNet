namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientSetExperience : IClientPacket
{
    public float ExperienceBar;
    public int Level;
    public int TotalExperience;
    public ClientSetExperience(float ExperienceBar, int Level, int TotalExperience)
    {
        this.ExperienceBar = ExperienceBar;
        this.Level = Level;
        this.TotalExperience = TotalExperience;
    }
    public int GetPacketId() => 0x1F;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteFloat(ExperienceBar);
        buffer.WriteVarInt(Level);
        buffer.WriteVarInt(TotalExperience);

        return buffer;
    }
}