namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientTimeUpdate : IClientPacket
{
    public long WorldAge;
    public long TimeOfDay;

    public ClientTimeUpdate(long WorldAge, long TimeOfDay)
    {
        this.WorldAge = WorldAge;
        this.TimeOfDay = TimeOfDay;
    }
    public int GetPacketId() => 0x03;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteLong(WorldAge);
        buffer.WriteLong(TimeOfDay);

        return buffer;
    }
}