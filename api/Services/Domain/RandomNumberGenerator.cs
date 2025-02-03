using System.Security.Cryptography;
using api.Services.Domain.Interfaces;

namespace api.Services.Domain;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new();

    public int GenerateRandomNumber(int min, int max)
    {
        if (min >= max) throw new ArgumentException("Min must be less than max.");

        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        byte[] data = new byte[4];
        rng.GetBytes(data);
        int value = BitConverter.ToInt32(data, 0) & int.MaxValue; 
        var rn = (value % (max - min + 1)) + min;
        return rn;
    }
}
