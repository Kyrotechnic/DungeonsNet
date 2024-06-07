using Dungeons.Server.User;

namespace Dungeons.Server.Managers;

public class ConnectionManager
{
    public List<DungeonsUser> Users = new();

    public ConnectionManager()
    {
        
    }

    public void AddUser(DungeonsUser user)
    {
        lock (Users)
        {
            Users.Add(user);
        }
    }

    public void RemoveUser(DungeonsUser user)
    {
        lock (Users)
        {
            Users.Remove(user);
        }
    }
}