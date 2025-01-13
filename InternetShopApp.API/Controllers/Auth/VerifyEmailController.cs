using InternetShopApp.Services.Interfaces.Auth;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Domain.Entities;
using InternetShopApp.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InternetShopApp.API.Controllers.Auth
{
    public class VerifyEmailController : Controller
    {

        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public VerifyEmailController (IUserService userService, IAuthService authService, IEmailService emailService)
        {
            _userService = userService;
            _authService = authService;
            _emailService = emailService;
        }


        [HttpGet("email/verify")]
        [AllowAnonymous]
        public IActionResult VerifyEmail([FromQuery] string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("YourSecretKeyHere");

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // Убираем временную задержку
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = jwtToken.Claims.First(x => x.Type == ClaimTypes.Email).Value;

                // Логика для верификации email в базе данных
                var user = _userService.GetByEmailAsync(email).Result;
                if (user == null)
                {
                    return NotFound(new { Error = "User not found" });
                }

                user.EmailVerified = true;
                _userService.UpdateAsync(user); // Сохранение изменений

                return Ok(new { Message = "Email successfully verified" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = "Invalid or expired token" });
            }
        }

        [HttpPost("email/verification-notification")]
        public async Task<IActionResult> ResendVerificationEmail([FromBody] ResendEmail request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound(new { Error = "User not found" });
            }

            if (user.EmailVerified)
            {
                return BadRequest(new { Message = "Email is already verified" });
            }

            var token = _authService.GenerateVerificationToken(user.Email);
            var verificationLink = $"https://example.com/email/verify?token={token}";

            await _emailService.SendAsync(user.Email, "Verify Your Email", $"Click this link to verify your email: {verificationLink}");

            return Ok(new { Message = "Verification email sent" });
        }


    }
}
