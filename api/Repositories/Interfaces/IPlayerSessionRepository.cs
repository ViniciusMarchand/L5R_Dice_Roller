using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IPlayerSessionRepository
    {
        Task<PlayerSession> AddPlayer(PlayerSession playerSession);
    }
}