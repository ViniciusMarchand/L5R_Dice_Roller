using System.Text.RegularExpressions;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;
using api.DTO;
using api.Repositories.Interfaces;
using api.Services.Domain.Interfaces;

namespace api.Repositories;

public class AuthRepository(ApplicationDbContext context, ITokenGeneratorService tokenGenerator) : IAuthRepository
{
    readonly ApplicationDbContext _context = context;
    readonly ITokenGeneratorService _tokenGenerator = tokenGenerator;

    public async Task<User> Login(UserLoginDTO dto) 
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username) ?? throw new KeyNotFoundException("Usuário não encontrado ou senha inválida");
        
        return user;
    }

    public async Task<User> Register(User user)
    {
        try
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        } 
        catch (DbUpdateException e)
        {
            var message = e.InnerException?.Message ?? string.Empty;
            if (message.Contains("IX_Users_Username"))
            {
                throw new Exception("Username unavailable");
            }
            else if (message.Contains("IX_Users_Email"))
            {
                throw new Exception("Email unavailable");
            }

            throw new Exception("Erro ao criar usuário.");
        }



    }
}