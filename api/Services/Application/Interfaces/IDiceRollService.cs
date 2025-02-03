using api.DTO;
using api.Enums;
using api.Models;

namespace api.Services.Application.Interfaces;

public interface IDiceRollService
{
    Task<DiceRollResponseDTO> CreateDiceRoll(DiceRollDTO diceRollDto, Guid userId);
    Task<DiceRoll> GetDiceRoll(Guid id);
    Task<List<DiceRoll>> GetDiceRolls();
    Task<DiceRoll> DeleteDiceRoll(Guid id);
    Task<List<DiceResponseDTO>> ChooseDice(List<Guid> guids, Guid diceRollId);
    Task<List<DiceRollResponseDTO>> GetDiceRollsBySessionId(Guid sessionId, Guid userId);
}