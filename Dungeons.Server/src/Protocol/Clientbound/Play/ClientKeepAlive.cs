namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientKeepAlive : IClientPacket
{
    public int KeepAliveId;
    public ClientKeepAlive(int KeepAliveId)
    {
        this.KeepAliveId = KeepAliveId;
    }
    public int GetPacketId() => 0x00;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(KeepAliveId);
    

        return buffer;
    }
}