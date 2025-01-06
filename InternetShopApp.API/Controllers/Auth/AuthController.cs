using InternetShopApp.Domain.Entities.Enum;
using InternetShopApp.Services.Interfaces.Auth;
using InternetShopApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using InternetShopApp.Domain.Entities.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

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


        //// POST: api/Auth/login
        //[HttpPost("login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login([FromBody] User request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var user = (await _userService.FindAsync(u => u.Email == request.Email)).FirstOrDefault();
        //    if (user == null || !_authService.VerifyPassword(request.PasswordHash, user.PasswordHash))
        //        return Unauthorized("Invalid email or password.");

        //    var token = _authService.GenerateJwtToken(user.Email, user.Role);
        //    return Ok(new { Token = token });
        //}


        // POST: api/Auth/login

        //[HttpPost("login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login([FromBody] JsonElement jsonData)
        //{
        //    // Проверяем, содержит ли запрос необходимые ключи
        //    if (!jsonData.TryGetProperty("Email", out var emailElement) ||
        //        !jsonData.TryGetProperty("PasswordHash", out var passwordHashElement))
        //    {
        //        return BadRequest(new { Error = "Both Email and PasswordHash are required.", status = 401, });
        //    }

        //    // Извлекаем значения из JSON
        //    var email = emailElement.GetString();
        //    var passwordHash = passwordHashElement.GetString();

        //    // Проверяем значения
        //    if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
        //    {
        //        return BadRequest(new { Error = "Invalid email address.", status = 401, });
        //    }

        //    if (string.IsNullOrWhiteSpace(passwordHash) || passwordHash.Length < 8)
        //    {
        //        return BadRequest(new { Error = "Password must be at least 8 characters long.", status = 401, });
        //    }

        //    // Ищем пользователя в базе данных
        //    //var user = (await _userService.FindAsync(u => u.Email == email)).FirstOrDefault();
        //    var user = await _userService.GetByEmailAsync(email);
        //    if (user == null )
        //    {
        //        return Unauthorized(new 
        //        { 
        //            Error = "User not found.",
        //            message = "User not found",
        //            status = 404,
        //        });
        //    }

        //    if (!_authService.VerifyPassword(passwordHash, user.PasswordHash))
        //    {
        //        return Unauthorized(new
        //        {
        //            Error = "Invalid email or password.",
        //            message = "Invalid email or password. Please try again.",
        //            status = 401,
        //        });
        //    }

        //    // Генерируем токен
        //    var token = _authService.GenerateJwtToken(user.Email, user.Role);
        //    return Ok(new 
        //    { 
        //        token = token,
        //        message = "Token has been generated.",
        //        status = 201,
        //        user = new
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            Role = user.Role
        //        }
        //    });
        //}

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Domain.Entities.DTOs.LoginRequest loginRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginRequest.Email) ||
                    !new EmailAddressAttribute().IsValid(loginRequest.Email))
                {
                    return BadRequest(new
                    {
                        Error = "Invalid email address.",
                        message = "Invalid email format.",
                        status = 400,
                    });
                }

                if (string.IsNullOrWhiteSpace(loginRequest.PasswordHash) ||
                    loginRequest.PasswordHash.Length < 8)
                {
                    return BadRequest(new
                    {
                        Error = "Password must be at least 8 characters long.",
                        message = "Password is too short.",
                        status = 400,
                    });
                }

                var user = await _userService.GetByEmailAsync(loginRequest.Email);
                if (user == null)
                {
                    return NotFound(new
                    {
                        Error = "User not found.",
                        message = "User not found.",
                        status = 404,
                    });
                }

                if (!_authService.VerifyPassword(loginRequest.PasswordHash, user.PasswordHash))
                {
                    return Unauthorized(new
                    {
                        Error = "Invalid email or password.",
                        message = "Invalid email or password. Please try again.",
                        status = 401,
                    });
                }

                var token = _authService.GenerateJwtToken(user.Email, user.Role);
                return Ok(new
                {
                    token = token,
                    message = "Token has been generated.",
                    status = 201,
                    user = new
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Role = user.Role,
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "An unexpected error occurred.",
                    message = ex.Message,
                    status = 500,
                });
            }
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


