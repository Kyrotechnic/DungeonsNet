using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientMultiBlockChange : IClientPacket
{
    public int ChunkX;
    public int ChunkZ;
    public ModifiedBlockRecord[] ModifiedBlockRecords;
    public ClientMultiBlockChange(int ChunkX, int ChunkZ, ModifiedBlockRecord[] ModifiedBlockRecords)
    {
        this.ChunkX = ChunkX;
        this.ChunkZ = ChunkZ;
        this.ModifiedBlockRecords = ModifiedBlockRecords;
    }
    public int GetPacketId() => 0x22;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(ChunkX);
        buffer.WriteInt(ChunkZ);
        buffer.WriteVarInt(ModifiedBlockRecords.Length);

        for (int i = 0; i < ModifiedBlockRecords.Length; i++) 
        {
            ModifiedBlockRecord current = ModifiedBlockRecords[i];
            buffer.WriteByte(current.HorizontalPosition);
            buffer.WriteByte(current.YCoordinate);
            buffer.WriteVarInt(current.BlockId);
        }

        return buffer;
    }
}