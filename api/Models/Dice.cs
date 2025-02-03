using System.Text.Json.Serialization;
using api.Enums;

namespace api.Models;

public class Dice
{

    public Dice(DiceType type, DiceRoll diceRoll, int result)
    {
        Type = type;
        Result = GenerateResult(result);
        DiceRollId = diceRoll.Id;
        // DiceRoll = diceRoll;
    }

    public Dice() { }

    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiceType Type { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DiceResult Result { get; set; }
    
    public Guid DiceRollId { get; set; }

    [JsonIgnore]
    public DiceRoll DiceRoll { get; set; } = null!;

    public bool IsChosen { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    private DiceResult GenerateResult(int result)
    {
        if(Type == DiceType.SKILL)
        {
            return result switch
            {
                1 => DiceResult.BLANK,
                2 => DiceResult.BLANK,
                3 => DiceResult.OPPORTUNITY,
                4 => DiceResult.OPPORTUNITY,
                5 => DiceResult.OPPORTUNITY,
                6 => DiceResult.SUCCESS_STRIFE,
                7 => DiceResult.SUCCESS_STRIFE,
                8 => DiceResult.SUCCESS,
                9 => DiceResult.SUCCESS,
                10 => DiceResult.SUCCESS_OPPORTUNITY,
                11 => DiceResult.EXPLOSIVE_SUCCESS_STRIFE,
                12 => DiceResult.EXPLOSIVE_SUCCESS,
                _ => DiceResult.BLANK,
            };
        }
        else
        {
            return result switch
            {
                1 => DiceResult.BLANK,
                2 => DiceResult.OPPORTUNITY_STRIFE,
                3 => DiceResult.OPPORTUNITY,
                4 => DiceResult.SUCCESS_STRIFE,
                5 => DiceResult.SUCCESS,
                6 => DiceResult.EXPLOSIVE_SUCCESS_STRIFE,
                _ => DiceResult.BLANK,
            };
        }
    }
}