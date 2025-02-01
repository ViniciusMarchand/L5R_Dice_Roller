using api.DTO;
using api.Models;

namespace api.Services.Application.Interfaces;

public interface IAuthService
{
    Task<AccessTokenDTO> Login(UserLoginDTO dto);
    Task<User> Register(UserDTO dto);
}
