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

        buffer.WriteVarInt(EntityId);
        buffer.WriteInt(Property.Length);
        
        for (int i = 0; i < Property.Length; i++) {
            EntityProperty current = Property[i];

            buffer.WriteString(current.Key);
            buffer.WriteDouble(current.Value);
            buffer.WriteVarInt(current.Modifiers.Length);

            for (int j = 0; j < current.Modifiers.Length; j++) {
                AttributeModifier currentModifier = current.Modifiers[i];
                buffer.WriteGuid(currentModifier.UUID);
                buffer.WriteDouble(currentModifier.Amount);
                buffer.WriteSByte(currentModifier.Operation);
            }
        }

        return buffer;
    }
}