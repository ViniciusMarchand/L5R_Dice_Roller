using System.ComponentModel.DataAnnotations;

namespace api.DTO;

public class DiceRollDTO
{
    [Required]
    public Guid SessionId { get; set; }

    [Required]
    public int SkillDiceQuantity { get; set; }

    [Required]
    public int RingDiceQuantity { get; set; } 
}