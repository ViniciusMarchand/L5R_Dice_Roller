using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using api.Services.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using api.DTO;
using System.Security.Claims;
using api.Enums;

namespace api.Controllers
{
    [Route("api/dice-roll")]
    [ApiController]
    public class DiceRollController(IDiceRollService diceRollService) : ControllerBase
    {

        private readonly IDiceRollService _diceRollService = diceRollService;


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<DiceRollResponseDTO>> CreateDiceRoll([FromBody] DiceRollDTO diceRoll)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            
            Guid userId = Guid.Parse(userIdClaim.Value);

            var sessions = await _diceRollService.CreateDiceRoll(diceRoll, userId);
            return Ok(sessions);
        }

        [HttpPost("choose-dice")]
        [Authorize]
        public async Task<ActionResult<bool>> ChooseDice([FromBody] ChooseDiceDTO dto)
        {
            // var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            // if (userIdClaim == null)
            // {
            //     return Unauthorized("User ID claim not found.");
            // }
            
            // Guid userId = Guid.Parse(userIdClaim.Value);

            var sessions = await _diceRollService.ChooseDice(dto.Ids, dto.DiceRollId);
            return Ok(sessions);
        }

        [HttpGet("rolls/sessionId/{sessionId}")]
        [Authorize]
        public async Task<ActionResult<bool>> ChooseDice(Guid sessionId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("User ID claim not found.");
            }
            
            Guid userId = Guid.Parse(userIdClaim.Value);

            var sessions = await _diceRollService.GetDiceRollsBySessionId(sessionId, userId);
            return Ok(sessions);
        }
    }
}
