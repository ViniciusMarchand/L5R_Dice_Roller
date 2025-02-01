using System.Text.RegularExpressions;
using api.DTO;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Application.Interfaces;
using api.Services.Domain.Interfaces;

namespace api.Services.Application;

public partial class AuthService(IAuthRepository authRepository, ITokenGeneratorService tokenGeneratorService) : IAuthService
{

    readonly IAuthRepository _authRepository = authRepository;
    readonly ITokenGeneratorService _tokenGeneratorService = tokenGeneratorService;

    public async Task<AccessTokenDTO> Login(UserLoginDTO dto)
    {

        User user = await _authRepository.Login(dto);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            throw new KeyNotFoundException("Usuário não encontrado ou senha inválida");
        }


        AccessTokenDTO token = new()
        {
            AccessToken = _tokenGeneratorService.GenerateToken(user)
        };

        return token;
    }

    public async Task<User> Register(UserDTO dto)
    {

        var Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        var emailRegex = MyRegex();

        if (!emailRegex.IsMatch(dto.Email))
            throw new Exception("Invalid email");
        
        var user = new User
        {
            Username = dto.Username,
            Password = Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
        
        return await _authRepository.Register(user);
    }

    [GeneratedRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    private static partial Regex MyRegex();
}
