using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class DiceRollRepository(ApplicationDbContext context) : IDiceRollRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<DiceRoll> CreateDiceRoll(DiceRoll diceRoll)
    {
        await _context.DiceRolls.AddAsync(diceRoll);
        await _context.SaveChangesAsync();
        return diceRoll;
    }

    public Task<DiceRoll> DeleteDiceRoll(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<DiceRoll> GetDiceRoll(Guid id)
    {
        DiceRoll diceRoll = await _context.DiceRolls.Where(d => d.Id == id).Include(d => d.Dices).FirstOrDefaultAsync() ?? throw new Exception("DiceRoll not found");
        return diceRoll;    
    }

    public Task<List<DiceRoll>> GetDiceRolls()
    {
        throw new NotImplementedException();
    }

    public async Task<DiceRoll> UpdateDiceRoll(DiceRoll diceRoll)
    {
        _context.DiceRolls.Update(diceRoll);
        await _context.SaveChangesAsync();
        return diceRoll;
    }

    public async Task<List<DiceRoll>> GetDiceRollsBySessionId(Guid sessionId, Guid userId)
    {
        List<DiceRoll> diceRolls = await _context.DiceRolls.Where(d => d.SessionId == sessionId && d.UserId == userId).Include(d => d.Dices).ToListAsync();
        return diceRolls;
    }
}