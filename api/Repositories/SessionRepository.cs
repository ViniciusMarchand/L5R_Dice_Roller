using api.Models;
using api.Repositories.Interfaces;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;
public class SessionRepository(ApplicationDbContext context) : ISessionRepository
{

    private readonly ApplicationDbContext context = context;

    public async Task<IEnumerable<Session>> GetSessions()
    {
        var sessions = await context.Sessions.Where(s => !s.IsDeleted).ToListAsync() ?? throw new KeyNotFoundException("No active session found.");

        return sessions;
    }

    public async Task<Session> GetSession(Guid id)
    {
        var session = await context.Sessions.Where(s => !s.IsDeleted && s.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Session with id {id} not found.");

        return session;
    }

    public async Task<Session> CreateSession(Session session)
    {
        await context.Sessions.AddAsync(session);
        await context.SaveChangesAsync();
        return session;
    }

    public async Task<Session> UpdateSession(Session session)
    {
        context.Sessions.Update(session);
        await context.SaveChangesAsync();
        return session;
    }
}