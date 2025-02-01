using api.Models;
using api.Repositories.Interfaces;
using api.Services;

namespace api.Repositories;

public class PlayerSessionRepository(ApplicationDbContext applicationDbContext) : IPlayerSessionRepository
{
    private readonly ApplicationDbContext _context = applicationDbContext;

    public async Task<PlayerSession> AddPlayer(PlayerSession playerSession)
    {
        await _context.PlayerSessions.AddAsync(playerSession);
        _context.SaveChanges();
        return playerSession;
    }
}