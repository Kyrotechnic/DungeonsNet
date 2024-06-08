namespace Dungeons.Server.Json;

public class JsonWriter
{
    public static string Serialize(JsonObject obj)
    {
        return obj.ToString();
    }
}