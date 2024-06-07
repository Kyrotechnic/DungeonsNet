namespace Dungeons.Server.Logger;

public class DungeonsLogger : ILogger
{
    public string name;
    public bool debug;
    public DungeonsLogger(string name, bool debug = false)
    {
        this.name = name;
        this.debug = debug;
    }

    public void LogDebug(string line)
    {
        if (debug)
            Console.WriteLine($"[{this.name}] [DEBUG] {line}");
    }

    public void LogError(string line)
    {
        Console.WriteLine($"[{this.name}] [ERROR] {line}");
    }

    public void LogInfo(string line)
    {
        Console.WriteLine($"[{this.name}] [INFO] {line}");
    }

    public void LogWarn(string line)
    {
        Console.WriteLine($"[{this.name}] [WARN] {line}");
    }
}