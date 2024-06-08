using System.Runtime.CompilerServices;
using Dungeons.Server.Api;

public struct EntityProperty
{
    public string Key {get; private set;}
    public double Value {get; private set;}
    public AttributeModifier[] Modifiers {get; private set;}

    public EntityProperty(string Key, double Value, AttributeModifier[] Modifiers) 
    {
        this.Key = Key;
        this.Value = Value;
        this.Modifiers = Modifiers;
    }
}