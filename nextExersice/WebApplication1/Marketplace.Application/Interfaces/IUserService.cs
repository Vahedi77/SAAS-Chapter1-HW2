using Marketplace.Domain;

namespace Marketplace.Application.Interfaces;

public interface IUserService
{ 
    User GetUserById(int id); 
    User GetUserByUsername(string username);
    void RegisterUser(User user);
}