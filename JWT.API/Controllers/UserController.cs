using JWT.API.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            List<LoginRequest> list = new List<LoginRequest>();
            list.Add(new LoginRequest { Name = "PPS", Password = "cA37U+MKzR9z2yAaNULyW9VfVRFkOSwnJhptKpieEay+kgdvlt1bic421a5yMmJo" });
            list.Add(new LoginRequest { Name = "EdnaModa", Password = "RXPuk8qLuabZXwo9gCvqzklpYyevqIzF9BJ5ElhWkdYIMg0iguUzOb5LacjC+7Z9" });
            list.Add(new LoginRequest { Name = "Naomi24", Password = "wbWC+eV7GwaPXcdDP3dOuCkNnBTLg2IHOd6Cpb/f3I8YhhfBr+vJw/t/nb7ga3NO" });

            return Ok(list);
        }
    }
}
