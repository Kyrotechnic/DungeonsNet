namespace Dungeons.Server.Json;

public class JsonValue : IJsonEntry
{
    private object value;
    public JsonValue(object value = default!)
    {
        this.value = value;
    }

    public override string ToString()
    {
        return "";
    }

    public JsonType GetJsonType() => JsonType.Value;
}