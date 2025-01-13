//using InternetShopApp.Domain.Entities.Enum;
//using InternetShopApp.Services.Interfaces.Auth;
//using InternetShopApp.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using InternetShopApp.Domain.Entities.DTOs;
//using System.ComponentModel.DataAnnotations;
//using System.Text.Json;

//namespace InternetShopApp.API.Controllers.Auth
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IAuthService _authService;

//        public AuthController(IUserService userService, IAuthService authService)
//        {
//            _userService = userService;
//            _authService = authService;
//        }


//        [HttpPost("login")]
//        [AllowAnonymous]
//        public async Task<IActionResult> Login([FromBody] Domain.Entities.DTOs.LoginRequest loginRequest)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(loginRequest.Email) ||
//                    !new EmailAddressAttribute().IsValid(loginRequest.Email))
//                {
//                    return BadRequest(new
//                    {
//                        Error = "Invalid email address.",
//                        message = "Invalid email format.",
//                        status = 400,
//                    });
//                }

//                if (string.IsNullOrWhiteSpace(loginRequest.PasswordHash) ||
//                    loginRequest.PasswordHash.Length < 8)
//                {
//                    return BadRequest(new
//                    {
//                        Error = "Password must be at least 8 characters long.",
//                        message = "Password is too short.",
//                        status = 400,
//                    });
//                }

//                var user = await _userService.GetByEmailAsync(loginRequest.Email);
//                if (user == null)
//                {
//                    return NotFound(new
//                    {
//                        Error = "User not found.",
//                        message = "User not found.",
//                        status = 404,
//                    });
//                }

//                if (!_authService.VerifyPassword(loginRequest.PasswordHash, user.PasswordHash))
//                {
//                    return Unauthorized(new
//                    {
//                        Error = "Invalid email or password.",
//                        message = "Invalid email or password. Please try again.",
//                        status = 401,
//                    });
//                }

//                var token = _authService.GenerateJwtToken(user.Email, user.Role);
//                return Ok(new
//                {
//                    token = token,
//                    message = "Token has been generated.",
//                    status = 201,
//                    user = new
//                    {
//                        Id = user.Id,
//                        Email = user.Email,
//                        Role = user.Role,
//                    }
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new
//                {
//                    Error = "An unexpected error occurred.",
//                    message = ex.Message,
//                    status = 500,
//                });
//            }
//       }




//        //// POST: api/Auth/logout
//        //[HttpPost("logout")]
//        //[Authorize]
//        //public IActionResult Logout()
//        //{
//        //    // На стороне сервера JWT нельзя "аннулировать" до истечения срока действия.
//        //    // Обычно для этого применяют чёрный список или обновляемые токены.
//        //    // Здесь можно просто удалить клиентский токен на стороне клиента.
//        //    return Ok("Logged out successfully.");
//        //}

//        // POST: api/Auth/logout
//        [HttpPost("logout")]
//        //[Authorize]
//        public IActionResult Logout([FromBody] LogoutRequest request)
//        {
//            bool result = _authService.RevokeRefreshToken(request.AccessToken, null);

//            if (result)
//            {
//                return Ok(new { message = "Logged out successfully" });
//            }

//            return BadRequest(new { message = "Failed to log out" });
//        }

//        public class LogoutRequest
//        {
//            public string AccessToken { get; set; }
//        }

//    }

//}



//using InternetShopApp.Domain.Entities.Enum;
//using InternetShopApp.Services.Interfaces.Auth;
//using InternetShopApp.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using InternetShopApp.Domain.Entities.DTOs;
//using System.ComponentModel.DataAnnotations;
//using System.Text.Json;

//namespace InternetShopApp.API.Controllers.Auth
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IUserService _userService;
//        private readonly IAuthService _authService;

//        public AuthController(IUserService userService, IAuthService authService)
//        {
//            _userService = userService;
//            _authService = authService;
//        }


//        [HttpPost("login")]
//        [AllowAnonymous]
//        public async Task<IActionResult> Login([FromBody] Domain.Entities.DTOs.LoginRequest loginRequest)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(loginRequest.Email) ||
//                    !new EmailAddressAttribute().IsValid(loginRequest.Email))
//                {
//                    return BadRequest(new
//                    {
//                        Error = "Invalid email address.",
//                        message = "Invalid email format.",
//                        status = 400,
//                    });
//                }

//                if (string.IsNullOrWhiteSpace(loginRequest.PasswordHash) ||
//                    loginRequest.PasswordHash.Length < 8)
//                {
//                    return BadRequest(new
//                    {
//                        Error = "Password must be at least 8 characters long.",
//                        message = "Password is too short.",
//                        status = 400,
//                    });
//                }

//                var user = await _userService.GetByEmailAsync(loginRequest.Email);
//                if (user == null)
//                {
//                    return NotFound(new
//                    {
//                        Error = "User not found.",
//                        message = "User not found.",
//                        status = 404,
//                    });
//                }

//                if (!_authService.VerifyPassword(loginRequest.PasswordHash, user.PasswordHash))
//                {
//                    return Unauthorized(new
//                    {
//                        Error = "Invalid email or password.",
//                        message = "Invalid email or password. Please try again.",
//                        status = 401,
//                    });
//                }

//                var token = _authService.GenerateJwtToken(user.Email, user.Role);
//                return Ok(new
//                {
//                    token = token,
//                    message = "Token has been generated.",
//                    status = 201,
//                    user = new
//                    {
//                        Id = user.Id,
//                        Email = user.Email,
//                        Role = user.Role,
//                    }
//                });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new
//                {
//                    Error = "An unexpected error occurred.",
//                    message = ex.Message,
//                    status = 500,
//                });
//            }
//        }



//        // POST: api/Auth/logout
//        [HttpPost("logout")]
//        //[Authorize]
//        public IActionResult Logout([FromBody] LogoutRequest request)
//        {
//            bool result = _authService.RevokeRefreshToken(request.AccessToken, null);

//            if (result)
//            {
//                return Ok(new { message = "Logged out successfully" });
//            }

//            return BadRequest(new { message = "Failed to log out" });
//        }

//        public class LogoutRequest
//        {
//            public string AccessToken { get; set; }
//        }

//    }

//}

//using InternetShopApp.Domain.Entities.DTOs;
//using InternetShopApp.Services.Interfaces.Auth;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace InternetShopApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        /// <summary>
//        /// Аутентификация и выдача токенов
//        /// </summary>
//        /// <param name="loginRequest">Данные для входа</param>
//        [HttpPost("login")]
//        public IActionResult Login([FromBody] LoginRequest loginRequest)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            // Проверяем учетные данные (логика проверки за пределами этого примера)
//            if (!_authService.VerifyPassword(loginRequest.PasswordHash, /* здесь должен быть хэш пароля из базы данных */))
//                return Unauthorized("Invalid username or password");

//            // Генерация accessToken и refreshToken
//            var accessToken = _authService.GenerateJwtToken(loginRequest.Email, loginRequest.Role);
//            var refreshToken = _authService.GenerateRefreshToken();

//            // Сохранение refreshToken в базе данных
//            _authService.SaveRefreshToken(loginRequest.Email, refreshToken);

//            return Ok(new TokenApiResponse
//            {
//                AccessToken = accessToken,
//                RefreshToken = refreshToken
//            });
//        }

//        /// <summary>
//        /// Обновление токенов
//        /// </summary>
//        /// <param name="tokenRequest">Запрос с accessToken и refreshToken</param>
//        [HttpPost("refresh-token")]
//        public IActionResult RefreshToken([FromBody] TokenApiRequest tokenRequest)
//        {
//            var newTokens = _authService.RefreshTokens(tokenRequest.AccessToken, tokenRequest.RefreshToken);

//            if (newTokens == null)
//                return Unauthorized("Invalid tokens or tokens expired");

//            return Ok(newTokens);
//        }

//        /// <summary>
//        /// Логаут пользователя (отзыв refreshToken)
//        /// </summary>
//        /// <param name="tokenRequest">Запрос с accessToken и refreshToken</param>
//        [HttpPost("logout")]
//        [Authorize]
//        public IActionResult Logout([FromBody] TokenApiRequest tokenRequest)
//        {
//            var result = _authService.RevokeRefreshToken(tokenRequest.AccessToken, tokenRequest.RefreshToken);

//            if (!result)
//                return BadRequest("Failed to revoke tokens");

//            return Ok("Logged out successfully");
//        }

//        /// <summary>
//        /// Проверка действительности токена
//        /// </summary>
//        [HttpGet("validate-token")]
//        [Authorize]
//        public IActionResult ValidateToken()
//        {
//            return Ok(new { Message = "Token is valid" });
//        }
//    }
//}

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


                // Генерация accessToken и refreshToken
                var token = _authService.GenerateJwtToken(user.Email, user.Role);
                var refreshToken = _authService.GenerateRefreshToken();

                // Сохранение refreshToken в базе данных
                _authService.SaveRefreshTokenAsync(user.Id, refreshToken);

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
        public IActionResult Logout([FromBody] LogoutRequest request)
        {
            //Token check
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var userClaims = HttpContext.User.Claims.ToList();


            //bool result = _authService.RevokeRefreshToken(request.AccessToken, null);
            bool result = _authService.RevokeRefreshToken(request.AccessToken);

            if (result)
            {
                return Ok(new { message = "Logged out successfully" });
            }

            return BadRequest(new { message = "Failed to log out" });
        }

        public class LogoutRequest
        {
            public string AccessToken { get; set; }
        }

    }

}
