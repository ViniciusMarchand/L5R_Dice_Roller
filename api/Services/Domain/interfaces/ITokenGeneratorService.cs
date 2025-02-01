using api.Models;

namespace api.Services.Domain.Interfaces;

public interface ITokenGeneratorService
{
    string GenerateToken(User user);
}