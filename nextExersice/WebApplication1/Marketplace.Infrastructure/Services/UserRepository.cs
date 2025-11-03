using Marketplace.Domain;
using Marketplace.Application;
using Marketplace.Application.Interfaces;

namespace Marketplace.Infrastructure.Services.Services;

public class UserRepository: IUserRepository
{
    private List<User> _users = new();

    public User FindById(int id)
    {
        return _users.FirstOrDefault(u => u.getId() == id);
    }
    
    public User FindByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }
    
    public void Add(User user)
    {
        _users.Add(user);
    }
}