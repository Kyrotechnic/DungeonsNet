using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientBlockAction : IClientPacket
{
    public Position Location;
    public byte Byte1;
    public byte Byte2;
    public int BlockType;
    public ClientBlockAction(Position Location, byte Byte1, byte Byte2, int BlockType)
    {
        this.Location = Location;
        this.Byte1 = Byte1;
        this.Byte2 = Byte2;
        this.BlockType = BlockType;
    }
    public int GetPacketId() => 0x24;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WritePosition(Location);
        buffer.WriteByte(Byte1);
        buffer.WriteByte(Byte2);
        buffer.WriteVarInt(BlockType);

        return buffer;
    }
}