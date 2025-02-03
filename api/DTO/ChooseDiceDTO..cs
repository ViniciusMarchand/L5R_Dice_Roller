using System.ComponentModel.DataAnnotations;

namespace api.DTO;

public class ChooseDiceDTO
{
    [Required]
    public Guid DiceRollId{ get; set; }

    [Required]
    public List<Guid> Ids { get; set; } = [];
}