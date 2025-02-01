using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Services.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using api.DTO;

namespace api.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController(ISessionService sessionService) : ControllerBase
    {

        private readonly ISessionService _sessionService = sessionService;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            var sessions = await _sessionService.GetSessions();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Session>> GetSession(Guid id)
        {
            var sessions = await _sessionService.GetSession(id);
            
            return Ok(sessions);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Session>> CreateSession([FromBody] SessionDTO session)
        {
            var sessions = await _sessionService.CreateSession(session);
            
            return Ok(sessions);
        }

        [HttpGet("add-player/session/{sessionId}/player/{playerId}")]
        [Authorize]
        public async Task<ActionResult<bool>> AddPlayerToSession(Guid sessionId, Guid playerId)
        {
            var sessions = await _sessionService.AddPlayer(sessionId, playerId);
            
            return Ok(sessions);
        }
    }
}
