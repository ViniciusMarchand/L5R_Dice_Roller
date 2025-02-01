using api.Enums;

namespace api.Models;

public class PlayerSession
{
    public Guid SessionId { get; set; }
    public Session Session { get; set; } = null!;

    public Guid PlayerId { get; set; }
    public User Player { get; set; } = null!;

    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public SessionRoles Role { get; set; } = SessionRoles.PLAYER;    
}

