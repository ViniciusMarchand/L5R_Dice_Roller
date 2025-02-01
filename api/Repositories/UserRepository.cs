using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
{

    private readonly ApplicationDbContext _context = applicationDbContext;

    public Task<User> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _context.Users.Where(u => !u.IsDeleted && u.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"User with id {id} not found.");
        
        return user;
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}