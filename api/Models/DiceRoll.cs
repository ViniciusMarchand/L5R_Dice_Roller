namespace api.Models;

public class DiceRoll
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateTime { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public int SessionId { get; set; }
    public Session Session { get; set; } = null!;
    public List<Dice> Dices { get; set; } = [];
    public bool IsDeleted { get; set; } = false;

}