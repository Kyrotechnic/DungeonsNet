namespace Dungeons.Server.Logger;

public interface ILogger
{
    public void LogWarn(string line);
    public void LogError(string line);
    public void LogInfo(string line);
    public void LogDebug(string line);
}