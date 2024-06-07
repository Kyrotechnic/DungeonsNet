namespace Dungeons.Server.Config;

public class ConfigReader
{
    private readonly Dictionary<string, object> config;
    private string path;
    public ConfigReader(string path) {
        config = new();

        this.path = path;
    }
    
    private void LoadConfig() {
        if (!File.Exists(path)) {
            throw new FileNotFoundException($"Config could not be found in: {path}");
        }

        string[] values = File.ReadAllLines(path);

        for (int i = 0; i < values.Length; i++)
        {
            string line = values[i].Trim();

            //Comment
            if (string.IsNullOrEmpty(line) || line.StartsWith(":"))
                continue;
                
            string[] keyAndValue = line.Split("=");

            if (keyAndValue.Length == 2) {
                string key = keyAndValue[0].Trim();
                string value = keyAndValue[1].Trim();

                config[key] = value;
            }
        }
    }

    public T Get<T>(string id, T defaultValue) {
        if (config.ContainsKey(id))
            return (T) config[id];
        
        Set(id, defaultValue);

        return defaultValue;
    }

    public void Set<T>(string id, T value)
    {
        config[id] = value!;
    }

    public void Save()
    {
        string[] values = new string[config.Count + 3];
        int index = 0;
        
        foreach (KeyValuePair<string, object> key in config)
        {
            values[index++] = $"{key.Key}={key.Value}";
        }

        values[index++] = "";
        values[index++] = ": THIS IS THE CONFIG FOR THE SERVER";
        values[index++] = ": DONT DO FUNNY SHIT MF";

        File.WriteAllLines(path, values);
    }

}
