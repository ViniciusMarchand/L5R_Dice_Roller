using api.DTO;
using api.Models;
using api.Repositories.Interfaces;
using api.Services.Application.Interfaces;

namespace api.Services.Application;

public class SessionService(ISessionRepository sessionRepository, IUserRepository userRepository) : ISessionService
{

    private readonly ISessionRepository _sessionRepository = sessionRepository;
    private readonly IUserRepository _userRepository = userRepository;

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
        
        return await _sessionRepository.CreateSession(session);
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
}