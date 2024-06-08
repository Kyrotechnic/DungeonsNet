namespace Dungeons.Server.Json;

public class JsonArray : IJsonEntry
{
    private List<IJsonEntry> values;
    public JsonArray(int count = 10)
    {
        values = new(count);
    }

    public JsonType GetJsonType()
    {
        return JsonType.Array;
    }

    public override string ToString()
    {
        return "test";
    }

    public int Count() => values.Count;
    public IJsonEntry Get(int i) => values[i];
    public void Add(IJsonEntry value) => values.Add(value);
    public void Remove(IJsonEntry value) => values.Remove(value);
    public void Set(int i, IJsonEntry value) => values[i] = value;
    public void ForEach(Action<int, IJsonEntry> action)
    {
        for (int i = 0; i < values.Count; i++)
            action(i, values[i]);
    }
}