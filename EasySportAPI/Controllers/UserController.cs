using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasySport_API.Controllers
{
    // 
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {

        // Liaison avec la BLL (Son Interface 'IUserServices' + Le nom '_userServices')
        private readonly IUserService _userService;
        // Construction de l'appel (Son Services 'UserController' avec comme params Interface 'IUserServices' et son nom et dans ce constructeur faire l'appel de liaison DAL 'userServices')
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    //

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(UserFormDTO user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _userService.Delete(Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(UserDTO user)
        {
            try
            {
                _userService.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                
                return Ok(_userService.GetById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); ;
            }
        } 
    }
}
