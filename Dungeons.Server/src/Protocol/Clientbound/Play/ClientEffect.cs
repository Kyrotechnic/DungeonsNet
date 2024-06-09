using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEffect : IClientPacket
{
    public int EntityId;
    public Position Location;
    public int Data;
    public bool DisableRelativeVolume;
    public ClientEffect(int entityId, Position location, int data, bool disableRelativeVolume)
    {
        EntityId = entityId;
        Location = location;
        Data = data;
        DisableRelativeVolume = disableRelativeVolume;
    }
    public int GetPacketId() => 0x28;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(EntityId);
        buffer.WritePosition(Location);
        buffer.WriteInt(Data);
        buffer.WriteBool(DisableRelativeVolume);

        return buffer;
    }
}