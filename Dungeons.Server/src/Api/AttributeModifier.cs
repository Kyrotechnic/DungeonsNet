namespace Dungeons.Server.Api;

public struct AttributeModifier 
{
    public string Key {get; private set;}
    public string Value {get; private set;}

    public AttributeModifier(string Key, string Value)
    {
        this.Key = Key;
        this.Value = Value;
    }
}