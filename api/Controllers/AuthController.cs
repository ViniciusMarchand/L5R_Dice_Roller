using Microsoft.AspNetCore.Mvc;

using api.Services;
using api.DTO;
using api.Repositories;

namespace api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(AuthRepository authRepository) : ControllerBase
    {
        readonly AuthRepository _authRepository = authRepository;

        [HttpPost("login")]
        public async Task<ActionResult<AccessTokenDTO>> Login(UserLoginDTO dto)
        {
            try
            {
                AccessTokenDTO token = await _authRepository.Login(dto);
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
                var user = await _authRepository.Register(dto);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
