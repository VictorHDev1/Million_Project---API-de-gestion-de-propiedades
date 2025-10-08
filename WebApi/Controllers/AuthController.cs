using Application.DTOs.Authorization;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Security;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // LOGIN: Genera un token JWT para un usuario válido
        [HttpPost("login")]
        public IActionResult Login([FromBody] Application.DTOs.Authorization.LoginRequest request)
        {
            //  Validacion credenciales  estas credenciales son para esta prueba, lo ideal es generar en bd con cifrado
            if (request.Username == "admin" && request.Password == "1234")
            {
                var (token, expiration) = _jwtService.GenerateToken(request.Username);
                return Ok(new LoginResponse
                {
                    Token = token,
                    Expiration = DateTime.UtcNow.AddMinutes(60)
                });
            }

            return Unauthorized("Invalid username or password");
        }

    }
}
