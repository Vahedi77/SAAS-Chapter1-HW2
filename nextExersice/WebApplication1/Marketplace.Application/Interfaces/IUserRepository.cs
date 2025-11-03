using Marketplace.Domain;

namespace Marketplace.Application.Interfaces;

public interface IUserRepository
{
    User FindById(int id);
    User FindByUsername(string username);
    void Add(User user);
}