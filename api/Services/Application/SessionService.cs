using api.DTO;
using api.Enums;
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

    public async Task<SessionResponseDTO> CreateSession(SessionDTO sessionDto, Guid userId)
    {
        User user = await _userRepository.GetUser(userId);

        Session session = new ()
        {
            Title = sessionDto.Title,
            Description = sessionDto.Description,
            OwnerId = userId,
            Owner = user
        };

        session = await _sessionRepository.CreateSession(session);

        PlayerSession playerSession = new()
        {
            SessionId = session.Id,
            // Session = session,
            PlayerId = userId,
            // Player = user
            Role = SessionRoles.GAME_MASTER
        };

        await _playerSessionRepository.AddPlayer(playerSession);
        
        SessionResponseDTO sessionResponse = new()
        {
            Id = session.Id,
            Title = session.Title,
            Description = session.Description,
            OwnerId = session.OwnerId,
            OwnerName = user.FirstName,
            OwnerLastName = user.LastName
        };
        
        return sessionResponse;
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