namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientStatistics : IClientPacket
{
    public Statistic[] Statistics;

    public ClientStatistics(Statistic[] statistics)
    {
        Statistics = statistics;
    }
    public int GetPacketId() => 0x37;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteVarInt(Statistics.Length);

        for (int i = 0; i < Statistics.Length; i++) {
            Statistic current = Statistics[i];

            buffer.WriteString(current.Name);
            buffer.WriteVarInt(current.Value);
        }

        return buffer;
    }
}