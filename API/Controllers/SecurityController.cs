using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public SecurityController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(UsuarioViewModel usuario)
        {
            if (usuario.Username.Equals("ralfs") && usuario.Password.Equals("123"))
            {
                string token = tokenService.GenerarToken(new Usuario()
                {
                    Username = usuario.Username,
                    Email = usuario.Email
                });

                return Ok(new { statusCode = StatusCodes.Status200OK, token = token });
            }
            else
                return BadRequest("Usuario o contraseña incorrecta");
        }


    }
}
