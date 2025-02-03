using System.ComponentModel.DataAnnotations;

namespace api.DTO;

public class SessionDTO
{
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
}