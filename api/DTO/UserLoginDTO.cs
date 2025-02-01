using System.ComponentModel.DataAnnotations;

namespace api.DTO
{
    public record UserLoginDTO
    {
        [Required]
        public string Username { get; init; } = string.Empty;

        [Required]
        public string Password { get; init; } = string.Empty;
    }
}