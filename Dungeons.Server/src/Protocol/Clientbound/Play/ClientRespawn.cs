namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientRespawn : IClientPacket
{
    public int Dimension;
    public byte Difficulty;
    public byte Gamemode;
    public string LevelType;
    public ClientRespawn(int Dimension, byte Difficulty, byte Gamemode, string LevelType)
    {
        this.Dimension = Dimension;
        this.Difficulty = Difficulty;
        this.Gamemode = Gamemode;
        this.LevelType = LevelType;
    }
    public int GetPacketId() => 0x07;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(Dimension);
        buffer.WriteByte(Difficulty);
        buffer.WriteByte(Gamemode);
        buffer.WriteString(LevelType);

        return buffer;
    }
}