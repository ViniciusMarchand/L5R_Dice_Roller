using api.Models;

namespace api.Repositories.Interfaces;

public interface IDiceRepository
{
    Task<List<Dice>> SaveDice(List<Dice> diceRoll);
    Task<Dice> GetDice(Guid id);
    Task<List<Dice>> GetDices();
    Task<Dice> DeleteDice(Guid id);
    Task<Dice> UpdateDice(Dice dice);
    Task<List<Dice>> GetDiceByDiceRollId(Guid diceRollId);
    Task<List<Dice>> UpdateDiceRange(List<Dice> dices);
}