using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class DiceRepository(ApplicationDbContext context) : IDiceRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Dice>> SaveDice(List<Dice> dice)
    {
        await _context.Dices.AddRangeAsync(dice);
        await _context.SaveChangesAsync();
        return dice;
    }

    public Task<Dice> DeleteDice(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Dice> GetDice(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Dice>> GetDices()
    {
        throw new NotImplementedException();
    }

    public async Task<Dice> UpdateDice(Dice dice)
    {
        _context.Dices.Update(dice);
        await _context.SaveChangesAsync();
        return dice;
    }

    public async Task<List<Dice>> GetDiceByDiceRollId(Guid diceRollId)
    {
        List<Dice> dice = await _context.Dices.Where(d => d.DiceRollId == diceRollId).ToListAsync();
        return dice;
    }
    
    public async Task<List<Dice>> UpdateDiceRange(List<Dice> dices)
    {
        _context.Dices.UpdateRange(dices);
        await _context.SaveChangesAsync();
        return dices;
    }
}