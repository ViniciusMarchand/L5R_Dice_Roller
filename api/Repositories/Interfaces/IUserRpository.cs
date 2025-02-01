using api.Models;

namespace api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(Guid id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(Guid id);
}