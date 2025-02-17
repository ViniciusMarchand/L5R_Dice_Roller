using System.Text.Json.Serialization;

namespace api.Models;

public class Session
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }

    [JsonIgnore]
    public User Owner { get; set; } = null!;

    [JsonIgnore]
    public List<DiceRoll> DiceRolls { get; set; } = [];

    [JsonIgnore]
    public List<PlayerSession> PlayersSessions { get; set; } = [];

    public bool IsDeleted { get; set; } = false;
}