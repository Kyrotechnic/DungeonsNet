namespace Dungeons.Server.Protocol;

public interface IClientPacket : IPacket
{
    public IBuffer Write();
}