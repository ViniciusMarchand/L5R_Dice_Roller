namespace api.Services.Domain.Interfaces;

public interface IRandomNumberGenerator
{
    int GenerateRandomNumber(int min, int max);
}
