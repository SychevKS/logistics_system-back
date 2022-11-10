namespace logistics_system_back.Controllers
{
    using logistics_system_back.Abstractions;
    using logistics_system_back.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    /// <summary>
    /// Контролер авторизации
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }


        [HttpPost("token")]
        public IActionResult Token(string login, string password)
        {
            var identity = GetIdentity(login, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(
                        AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                    );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Json(encodedJwt);
        }

        private ClaimsIdentity? GetIdentity(string login, string password)
        {
            User? user = _userService.GetUser(login, password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                };
                ClaimsIdentity claimsIdentity = new(
                    claims, 
                    "Token", 
                    ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType
                );
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
