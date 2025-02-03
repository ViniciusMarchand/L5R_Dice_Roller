namespace api.Repositories.Interfaces;

using api.Models;

public interface IDiceRollRepository
{
    Task<DiceRoll> CreateDiceRoll(DiceRoll diceRoll);
    Task<DiceRoll> GetDiceRoll(Guid id);
    Task<List<DiceRoll>> GetDiceRolls();
    Task<DiceRoll> DeleteDiceRoll(Guid id);
    Task<List<DiceRoll>> GetDiceRollsBySessionId(Guid sessionId, Guid userId);
    Task<DiceRoll> UpdateDiceRoll(DiceRoll diceRoll);
}