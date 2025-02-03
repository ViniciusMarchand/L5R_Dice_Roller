using System.Text.Json.Serialization;
using api.Enums;

namespace api.Models;

public class PlayerSession
{
    public Guid SessionId { get; set; }
    [JsonIgnore]
    public Session Session { get; set; } = null!;

    public Guid PlayerId { get; set; }

    [JsonIgnore]
    public User Player { get; set; } = null!;

    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public SessionRoles Role { get; set; } = SessionRoles.PLAYER;    
}

