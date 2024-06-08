namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientChunkData : IClientPacket
{
    public int ChunkX;
    public int ChunkZ;
    public bool GroundUpContinuos;
    public byte PrimaryBitMask;
    public ClientChunkData()
    {

    }
    public int GetPacketId() => 0x21;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}