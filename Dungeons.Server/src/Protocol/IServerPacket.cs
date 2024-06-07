namespace Dungeons.Server.Protocol;

public interface IServerPacket : IPacket
{
    public void Read(IBuffer buffer);
}