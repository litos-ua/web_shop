
//using InternetShopApp.Services.Interfaces.Auth;
//using InternetShopApp.Domain.Entities.DTOs;
//using Microsoft.AspNetCore.Mvc;

//namespace InternetShopApp.API.Controllers.Auth
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class TokenController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public TokenController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("refresh")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public IActionResult RefreshToken([FromBody] TokenApiRequest request)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
//                {
//                    return BadRequest("Access token and refresh token are required");
//                }

//                var response = _authService.RefreshTokens(request.AccessToken, request.RefreshToken);

//                if (response == null || string.IsNullOrEmpty(response.AccessToken) || string.IsNullOrEmpty(response.RefreshToken))
//                {
//                    return Unauthorized("Invalid token pair");
//                }

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                // Логируйте исключение, если это необходимо
//                return StatusCode(500, "An unexpected error occurred");
//            }
//        }



//        [HttpPost("revoke")]
//        public IActionResult RevokeToken([FromBody] TokenApiRequest request)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
//                {
//                    return BadRequest("Access token and refresh token are required");
//                }

//                var result = _authService.RevokeRefreshToken(request.AccessToken, request.RefreshToken);

//                if (!result)
//                {
//                    return BadRequest("Failed to revoke token. Ensure the token pair is valid and active.");
//                }

//                return Ok(new { Message = "Token revoked successfully" });
//            }
//            catch (Exception ex)
//            {
//                // Логируйте исключение, если это необходимо
//                return StatusCode(500, "An unexpected error occurred");
//            }
//        }



//    }

//}

using InternetShopApp.Services.Interfaces.Auth;
using InternetShopApp.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopApp.API.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IAuthService authService, ILogger<TokenController> logger)
        {
            _authService = authService;
            _logger = logger;
        }


        // GET: api/UserToken
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tokens = await _authService.GetAllAsync();
            return Ok(tokens);
        }


        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RefreshToken([FromBody] TokenApiRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
                {
                    return BadRequest("Access token and refresh token are required");
                }

                if (!IsJwtTokenValid(request.AccessToken) || !IsJwtTokenValid(request.RefreshToken))
                {
                    return BadRequest("Invalid token format");
                }

                var response = _authService.RefreshTokens(request.AccessToken, request.RefreshToken);

                if (response == null)
                {
                    return StatusCode(403, "Invalid or expired token pair");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while refreshing the token.");
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPost("revoke")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RevokeToken([FromBody] TokenApiRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.RefreshToken))
                {
                    return BadRequest("Access token and refresh token are required");
                }

                if (!IsJwtTokenValid(request.AccessToken) || !IsJwtTokenValid(request.RefreshToken))
                {
                    return BadRequest("Invalid token format");
                }

                var result = _authService.RevokeRefreshToken(request.AccessToken);

                if (!result)
                {
                    return BadRequest("Failed to revoke token. Ensure the token pair is valid and active.");
                }

                return Ok(new { Message = "Token revoked successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while revoking the token.");
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        private bool IsJwtTokenValid(string token)
        {
            // Добавьте проверку на JWT-структуру и формат
            return !string.IsNullOrEmpty(token) && token.Split('.').Length == 3;
        }
    }
}
