using System.ComponentModel.DataAnnotations;

namespace api.DTO;

public class SessionResponseDTO
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public Guid OwnerId { get; set; }

    [Required]
    public string OwnerName { get; set; } = string.Empty;

    [Required]
    public string OwnerLastName { get; set; } = string.Empty;

}