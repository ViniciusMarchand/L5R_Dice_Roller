using System.ComponentModel.DataAnnotations;

namespace api.DTO;

public class DiceResultsDTO
{
    [Required]
    public int Successes { get; set; }

    [Required]
    public int Strifes { get; set; }

    [Required]
    public int Opportunities { get; set; }
}
