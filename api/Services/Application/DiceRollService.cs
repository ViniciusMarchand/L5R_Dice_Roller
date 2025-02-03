using api.DTO;
using api.Enums;
using api.Models;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services.Application.Interfaces;
using api.Services.Domain.Interfaces;

namespace api.Services.Application;

public class DiceRollService(IDiceRollRepository diceRollRepository, ISessionRepository sessionRepository, IUserRepository userRepository, IRandomNumberGenerator randomNumberGenerator, IDiceRepository diceRepository) : IDiceRollService
{
    private readonly IDiceRollRepository _diceRollRepository = diceRollRepository;
    private readonly ISessionRepository _sessionRepository = sessionRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRandomNumberGenerator _randomNumberGenerator = randomNumberGenerator;

    private readonly IDiceRepository _diceRepository = diceRepository;


    public async Task<DiceRollResponseDTO> CreateDiceRoll(DiceRollDTO diceRollDto, Guid userId)
    {
        User user = await _userRepository.GetUser(userId);
        Session session = await _sessionRepository.GetSession(diceRollDto.SessionId);

        DiceRoll diceRoll = new()
        {
            SessionId = diceRollDto.SessionId,
            // Session = session,
            UserId = userId,
            // User = user,
        };

        List<Dice> dice = RollDice(diceRollDto.SkillDiceQuantity, diceRollDto.RingDiceQuantity, diceRoll);

        diceRoll.Dices = dice;

        await _diceRollRepository.CreateDiceRoll(diceRoll);

        DiceRollResponseDTO diceRollResponse = MappingDTO(diceRoll, dice);

        return diceRollResponse;
    }

    public async Task<DiceRoll> DeleteDiceRoll(Guid id)
    {
        return await _diceRollRepository.DeleteDiceRoll(id);
    }

    public async Task<DiceRoll> GetDiceRoll(Guid id)
    {
        return await _diceRollRepository.GetDiceRoll(id);
    }

    public async Task<List<DiceRoll>> GetDiceRolls()
    {
        return await _diceRollRepository.GetDiceRolls();
    }

    public async Task<List<DiceResponseDTO>> ChooseDice(List<Guid> guids, Guid diceRollId)
    {
        DiceRoll diceRoll = await _diceRollRepository.GetDiceRoll(diceRollId);

        List<Dice> dice = await _diceRepository.GetDiceByDiceRollId(diceRollId);

        foreach (Guid guid in guids)
        {
            Dice die = dice.FirstOrDefault(d => d.Id == guid)!;
            if (die == null)
            {
                continue;
            }
            die.IsChosen = true;
        }

        await _diceRepository.UpdateDiceRange(dice);

        diceRoll.HasAlreadyBeenChosen = true;

        DiceResultsDTO results = GetResultsFromDiceRoll(dice);

        diceRoll.Strifes = results.Strifes;
        diceRoll.Successes = results.Successes;
        diceRoll.Opportunities = results.Opportunities;

        await _diceRollRepository.UpdateDiceRoll(diceRoll);

        return MappingDTO(dice);
    }

    private List<Dice> RollDice(int skillDiceQnt, int ringDiceQnt, DiceRoll diceRoll)
    {
        List<Dice> dice = [];

        for (int i = 0; i < skillDiceQnt; i++)
        {
            int rn = _randomNumberGenerator.GenerateRandomNumber(1, 12);

            dice.Add(new Dice(
                DiceType.SKILL,
                diceRoll,
                rn
            ));
        }

        for (int i = 0; i < ringDiceQnt; i++)
        {
            int rn = _randomNumberGenerator.GenerateRandomNumber(1, 6);
            dice.Add(new Dice(

                DiceType.RING,
                diceRoll,
                rn
            ));
        }

        return dice;
    }

    public async Task<List<DiceRollResponseDTO>> GetDiceRollsBySessionId(Guid sessionId, Guid userId)
    {
        List<DiceRoll> diceRolls = await _diceRollRepository.GetDiceRollsBySessionId(sessionId, userId);

        List<DiceRollResponseDTO> diceRollsResponse = [.. diceRolls.Select(d => MappingDTO(d, d.Dices))];

        return MappingDTO(diceRolls);
    }

    private static DiceRollResponseDTO MappingDTO(DiceRoll diceRoll, List<Dice> dice)
    {
        List<DiceResponseDTO> diceResponse = [.. dice.Select(d => new DiceResponseDTO
        {
            Id = d.Id,
            Result = d.Result.ToString(),
            Type = d.Type.ToString(),
            DiceRollId = d.DiceRollId,
            IsChosen = d.IsChosen
        })];

        DiceRollResponseDTO diceRollResponse = new()
        {
            Id = diceRoll.Id,
            SessionId = diceRoll.SessionId,
            UserId = diceRoll.UserId,
            Dice = diceResponse,
            Strife = diceRoll.Strifes,
            Success = diceRoll.Successes,
            Opportunity = diceRoll.Opportunities,
        };

        return diceRollResponse;
    }

    private static List<DiceRollResponseDTO> MappingDTO(List<DiceRoll> diceRolls)
    {
        List<DiceRollResponseDTO> diceRollsResponse = [.. diceRolls.Select(d => MappingDTO(d, d.Dices))];

        return diceRollsResponse;
    }

    private static List<DiceResponseDTO> MappingDTO(List<Dice> dice)
    {
        List<DiceResponseDTO> diceResponse = [.. dice.Select(d => new DiceResponseDTO
        {
            Id = d.Id,
            Result = d.Result.ToString(),
            Type = d.Type.ToString(),
            DiceRollId = d.DiceRollId,
            IsChosen = d.IsChosen
        })];

        return diceResponse;
    }

    private static DiceResultsDTO GetResultsFromDiceRoll(List<Dice> dice)
    {
        int strifes = dice.Where(d => d.IsChosen && (
            d.Result == DiceResult.OPPORTUNITY_STRIFE ||
            d.Result == DiceResult.SUCCESS_OPPORTUNITY ||
            d.Result == DiceResult.EXPLOSIVE_SUCCESS_STRIFE ||
            d.Result == DiceResult.SUCCESS_STRIFE
)       ).Count();

        int success = dice.Where(d => d.IsChosen && (
            d.Result == DiceResult.SUCCESS ||
            d.Result == DiceResult.EXPLOSIVE_SUCCESS ||
            d.Result == DiceResult.SUCCESS_OPPORTUNITY ||
            d.Result == DiceResult.EXPLOSIVE_SUCCESS_STRIFE ||
            d.Result == DiceResult.SUCCESS_STRIFE
        )).Count();

        int opportunity = dice.Where(d => d.IsChosen && (
            d.Result == DiceResult.OPPORTUNITY ||
            d.Result == DiceResult.SUCCESS_OPPORTUNITY ||
            d.Result == DiceResult.OPPORTUNITY_STRIFE
        )).Count();

        return new DiceResultsDTO
        {
            Strifes = strifes,
            Successes = success,
            Opportunities = opportunity
        };
    }
}