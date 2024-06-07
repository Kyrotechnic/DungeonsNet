namespace Dungeons.Server.Protocol.Clientbound.Play;

public class ClientUpdateHealth : IClientPacket
{
    public float Health;
    public int Food;
    public float FoodSaturation;
    public ClientUpdateHealth(float Health, int Food, float FoodSaturation)
    {
        this.Health = Health;
        this.Food = Food;
        this.FoodSaturation = FoodSaturation;
    }
    public int GetPacketId() => 0x06;

    public IBuffer Write()
    {
        IBuffer buffer = IBuffer.Create();

        buffer.WriteFloat(Health);
        buffer.WriteInt(Food);
        buffer.WriteFloat(FoodSaturation);

        return buffer;
    }
}