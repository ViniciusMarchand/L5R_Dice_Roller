using api.Models;

namespace api.Repositories.Interfaces;

public interface ISessionRepository
{
    Task<IEnumerable<Session>> GetSessions();
    Task<Session> GetSession(Guid id);
    Task<Session> CreateSession(Session session);
    Task<Session> UpdateSession(Session session);
}