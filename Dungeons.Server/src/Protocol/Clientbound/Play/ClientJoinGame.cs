namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientJoinGame : IClientPacket
{
    public int EntityId;
    public byte Gamemode;
    public sbyte Dimension;
    public byte Difficulty;
    public byte MaxPlayers;
    public string LevelType;
    public bool ReducedDebugInfo;
    public ClientJoinGame(int EntityId, byte Gamemode, sbyte Dimension, byte Difficulty, byte MaxPlayers, string LevelType, bool ReducedDebugInfo) 
    {
        this.EntityId = EntityId;
        this.Gamemode = Gamemode;
        this.Dimension = Dimension;
        this.Difficulty = Difficulty;
        this.MaxPlayers = MaxPlayers;
        this.LevelType = LevelType;
        this.ReducedDebugInfo = ReducedDebugInfo;

    }
    public int GetPacketId() => 0x01;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(EntityId);
        buffer.WriteByte(Gamemode);
        buffer.WriteSByte(Dimension);
        buffer.WriteByte(Difficulty);
        buffer.WriteByte(MaxPlayers);
        buffer.WriteString(LevelType);
        buffer.WriteBool(ReducedDebugInfo);

        return buffer;
    }
}