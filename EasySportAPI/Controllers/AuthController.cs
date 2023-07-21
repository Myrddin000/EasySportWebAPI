using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace EasySport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        public IConfiguration _Configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _AuthService = authService;
            _Configuration = configuration;
        }

        [HttpPost]
        [Produces(typeof(TokenDTO))]

        public IActionResult Post(LoginDTO dto)
        {

            try
            {
                 return Ok(_AuthService.Auth(dto));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);    
            }
                 
        }

    }
}
