using System.Text.Json.Serialization;

namespace api.Models;

public class DiceRoll
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }

    [JsonIgnore]
    public User User { get; set; } = null!;
    
    public Guid SessionId { get; set; }

    [JsonIgnore]
    public Session Session { get; set; } = null!;
    public List<Dice> Dices { get; set; } = [];
    public bool HasAlreadyBeenChosen { get; set; } = false;

    public int Strifes { get; set; }
    public int Successes { get; set; }
    public int Opportunities { get; set; }

    public bool IsDeleted { get; set; } = false;


}