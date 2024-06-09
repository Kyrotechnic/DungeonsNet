using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientBlockChange : IClientPacket
{
    public Position Location;
    public int BlockId;
    public ClientBlockChange(Position Location, int BlockId)
    {
        this.Location = Location;
        this.BlockId = BlockId;
    }
    public int GetPacketId() => 0x23;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WritePosition(Location);
        buffer.WriteVarInt(BlockId);

        return buffer;
    }
}