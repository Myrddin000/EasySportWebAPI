using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]

        public IActionResult Create(GameFormDTO game)
        {
            try
            {
                _gameService.Create(game);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_gameService.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


        [HttpGet("headcount")]
        public IActionResult GetHeadcount(Guid Id)
        {
            try
            {
                return Ok(_gameService.GetHeadcount(Id));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(GameFormDTO game)
        {
            try
            {
                _gameService.Update(game);
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
                _gameService.Delete(Id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }





}

