namespace Dungeons.Server.Json;

public class JsonObject : IJsonEntry
{
    private Dictionary<string, IJsonEntry> map = new();

    public JsonObject()
    {

    }

    public override string ToString()
    {
        return "";
    }

    public IJsonEntry Get(string key) => map[key];
    public bool Has(string key) => map.ContainsKey(key);
    public void Remove(string key) => map.Remove(key);
    public void Set(string key, IJsonEntry value) => map[key] = value;
    public Dictionary<string, IJsonEntry> GetDictionary() => map;

    public JsonType GetJsonType()
    {
        return JsonType.Object;
    }
}