using api.DTO;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Application.Interfaces;

namespace api.Services.Application;

public class SessionService(ISessionRepository sessionRepository, IUserRepository userRepository, IPlayerSessionRepository playerSessionRepository) : ISessionService
{

    private readonly ISessionRepository _sessionRepository = sessionRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPlayerSessionRepository _playerSessionRepository = playerSessionRepository;

    public async Task<IEnumerable<Session>> GetSessions()
    {
        return await _sessionRepository.GetSessions();
    }

    public async Task<Session> CreateSession(SessionDTO sessionDto)
    {
        User user = await _userRepository.GetUser(sessionDto.OwnerId);

        Session session = new ()
        {
            Title = sessionDto.Title,
            Description = sessionDto.Description,
            OwnerId = sessionDto.OwnerId,
            Owner = user
        };

        session = await _sessionRepository.CreateSession(session);

        PlayerSession playerSession = new()
        {
            SessionId = session.Id,
            Session = session,
            PlayerId = sessionDto.OwnerId,
            Player = user
        };

        await _playerSessionRepository.AddPlayer(playerSession);
        
        return session;
    }

    public Task<Session> DeleteSession(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Session> GetSession(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Session> UpdateSession(SessionDTO session)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddPlayer(Guid sessionId, Guid playerId)
    {
        Session session = await _sessionRepository.GetSession(sessionId);
        User user = await _userRepository.GetUser(playerId);

        PlayerSession playerSession = new()
        {
            SessionId = sessionId,
            PlayerId = playerId,
            Player = user,
            Session = session
        }; 

        await _playerSessionRepository.AddPlayer(playerSession);

        return true;
    }
}