using Dungeons.Server.Api;
namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientEntityProperties : IClientPacket
{
    public int EntityId;
    public EntityProperty[] Property;
    public ClientEntityProperties(int EntityId, EntityProperty[] Property)
    {
        this.EntityId = EntityId;
        this.Property = Property;
    }
    public int GetPacketId() => 0x20;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        

        return buffer;
    }
}