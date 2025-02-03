using api.Models;

namespace api.Enums;

public class DiceRollResponseDTO
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }

    public int Success { get; set; }
    public int Strife { get; set; } 
    public int Opportunity { get; set; }
    
    public List<DiceResponseDTO> Dice { get; set; } = [];
}
