using InternetShopApp.Domain.Entities.Enum;
using InternetShopApp.Services.Interfaces.Auth;
using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.API.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        // POST: api/Auth/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] User request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = (await _userService.GetByEmailAsync(request.Email));
            if (existingUser != null)
                return Conflict("User with this email already exists.");

            request.PasswordHash = _authService.HashPassword(request.PasswordHash);
            request.Role = UserRole.User;

            await _userService.AddAsync(request);
            return Ok("User registered successfully.");
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = (await _userService.FindAsync(u => u.Email == request.Email)).FirstOrDefault();
            if (user == null || !_authService.VerifyPassword(request.PasswordHash, user.PasswordHash))
                return Unauthorized("Invalid email or password.");

            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            return Ok(new { Token = token });
        }

        // POST: api/Auth/logout
        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // На стороне сервера JWT нельзя "аннулировать" до истечения срока действия.
            // Обычно для этого применяют чёрный список или обновляемые токены.
            // Здесь можно просто удалить клиентский токен на стороне клиента.
            return Ok("Logged out successfully.");
        }
    }

}


