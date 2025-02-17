using api.DTO;
using api.Models;

namespace api.Services.Application.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<Session>> GetSessions();
    Task<Session> GetSession(Guid id);
    Task<SessionResponseDTO> CreateSession(SessionDTO session, Guid userId);
    Task<Session> UpdateSession(SessionDTO session);
    Task<Session> DeleteSession(Guid id);
    Task<bool> AddPlayer(Guid sessionId, Guid playerId);
}