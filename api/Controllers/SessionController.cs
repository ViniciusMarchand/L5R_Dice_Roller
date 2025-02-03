using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Services.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using api.DTO;
using System.Security.Claims;

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
        public async Task<ActionResult<SessionResponseDTO>> CreateSession([FromBody] SessionDTO session)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            
            Guid userId = Guid.Parse(userIdClaim.Value);

            var sessions = await _sessionService.CreateSession(session, userId);
            
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
