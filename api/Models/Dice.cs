using api.Enums;

namespace api.Models;

public class Dice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DiceType Type { get; set; }
    public int Result { get; set; }
    public Guid DiceRollId { get; set; }
    public DiceRoll DiceRoll { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}