using Marketplace.Domain;

namespace Marketplace.Application;

public class UserService
{
    private List<User> users = new List<User>();

    public bool Register(User newUser)
    {
        if (users.Count == 0)
        {
            users.Add(newUser);
            return true;
        }
        else
        {
            for (int i=0; i<users.Count; i++)
            {
                if (users[i].Username == newUser.Username)
                    return false;
            }
            users.Add(newUser);
            return true;
        }
    }

    public User Login(string username, string password)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Username == username && users[i].Password == password)
            {
                return users[i];
            }
        }
        return null;
    }

    public bool UpdateUser(string username,string newEmail)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Username == username)
            {
                users[i].Email = newEmail;
                return true;
            }
        }
        return false;
    }
}