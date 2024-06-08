namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientAttachEntity : IClientPacket
{
    public int EntityId;
    public int VehicleId;
    public bool Leash;
    public ClientAttachEntity(int EntityId, int VehicleId, bool Leash) 
    {
        this.EntityId = EntityId;
        this.VehicleId = VehicleId;
        this.Leash = Leash;
    }
    public int GetPacketId() => 0x1B;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteInt(EntityId);
        buffer.WriteVarInt(VehicleId);
        buffer.WriteBool(Leash);

        return buffer;
    }
}