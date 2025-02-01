using api.DTO;
using api.Models;

namespace api.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<User> Login(UserLoginDTO dto);
    Task<User> Register(UserDTO dto);
}

