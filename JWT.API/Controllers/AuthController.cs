using JWT.API.Models.Login;
using JWT.API.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService jwtService;

        public AuthController(JwtService _jwtService)
        {
            jwtService = _jwtService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            string token = string.Empty;
            try
            {
               var result = await jwtService.Authenticate(loginRequest);

                if (result == null)
                    return Unauthorized();

                token = result.Token;
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }


            return Ok(token);
        }
    }
}
