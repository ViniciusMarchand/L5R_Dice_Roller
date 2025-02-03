using System.ComponentModel.DataAnnotations;

namespace api.Enums;

public class DiceResponseDTO
{
    public Guid Id { get; set; }
    
    [EnumDataType(typeof(DiceType))]
    public string Type { get; set; } = string.Empty;

    [EnumDataType(typeof(DiceResult))]
    public string Result { get; set; } = string.Empty;

    public Guid DiceRollId { get; set; }

    public bool IsChosen { get; set; } = false;
}