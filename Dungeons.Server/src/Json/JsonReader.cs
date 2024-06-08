namespace Dungeons.Server.Json;

public class JsonReader
{
    public static IJsonEntry ReadFromString(string line)
    {
        LineReader reader = new(line);

        reader.SkipWhitespace();

        IJsonEntry entry;

        switch (reader.Get())
        {
            case '[':
                entry = ReadJsonArray(reader);
                break;
            case '{':
                entry = ReadJsonObject(reader);
                break;
            default:
                throw new Exception("Invalid character!");
        }

        return entry;
    }

    public static JsonArray ReadJsonArray(LineReader reader)
    {
        
    }

    public static JsonObject ReadJsonObject(LineReader reader)
    {

    }

    public static string ReadKey(LineReader reader)
    {
        reader.SkipWhitespace();

        string key = ReadString(reader);

        reader.SkipWhitespace();
        reader.Assert(":");
    }

    public static string ReadString(LineReader reader)
    {
        if (reader.Get() != '"')
            throw new Exception("Invalid character exception whilst reading string");
        
        string line = "";
        char c;
        char prev = ' ';

        while ((c = reader.Get()) != '"' || prev == '\\')
        {
            prev = c;
        }
        
        return line;
    }
}