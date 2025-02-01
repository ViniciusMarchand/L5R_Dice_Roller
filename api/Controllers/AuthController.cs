using Microsoft.AspNetCore.Mvc;

using api.Services;
using api.DTO;
using api.Repositories;
using api.Services.Application.Interfaces;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        readonly IAuthService _authService = authService;

        [HttpPost("login")]
        public async Task<ActionResult<AccessTokenDTO>> Login(UserLoginDTO dto)
        {
            try
            {
                AccessTokenDTO token = await _authService.Login(dto);
                return Ok(token);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost("register")]
        public async Task<ActionResult<AccessTokenDTO>> Register(UserDTO dto)
        {
            try
            {
                var user = await _authService.Register(dto);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
