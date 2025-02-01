using api.DTO;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Application.Interfaces;
using api.Services.Domain.Interfaces;

namespace api.Services.Application;

public class AuthService(IAuthRepository authRepository, ITokenGeneratorService tokenGeneratorService) : IAuthService
{

    readonly IAuthRepository _authRepository = authRepository;
    readonly ITokenGeneratorService _tokenGeneratorService = tokenGeneratorService;

    public async Task<AccessTokenDTO> Login(UserLoginDTO dto)
    {

        User user = await _authRepository.Login(dto);

        AccessTokenDTO token = new()
        {
            AccessToken = _tokenGeneratorService.GenerateToken(user)
        };

        return token;
    }

    public async Task<User> Register(UserDTO dto)
    {
        return await _authRepository.Register(dto);
    }
}
