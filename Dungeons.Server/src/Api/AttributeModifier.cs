namespace Dungeons.Server.Api;

public struct AttributeModifier 
{
    public Guid UUID {get; private set;}
    public double Amount {get; private set;}
    public sbyte Operation {get; private set;}

    public AttributeModifier(Guid UUID, double Amount, sbyte Operation)
    {
        this.UUID = UUID;
        this.Amount = Amount;
        this.Operation = Operation;
    }
}