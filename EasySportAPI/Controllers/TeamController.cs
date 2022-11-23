using EasySport_BLL.Interfaces;
using EasySport_BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasySport_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]

        public IActionResult Create(TeamFormDTO team)
        {
            try
            {
                //team.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _teamService.Create(team);
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
                return Ok(_teamService.GetAll());
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetDetails(Guid Id)
        {
            try
            {
                return Ok(_teamService.GetDetails(Id));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(TeamFormDTO team)
        {
            try
            {
                _teamService.Update(team);
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
                _teamService.Delete(Id);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        
        [HttpPost("{TeamId}")]
        [Authorize]
        public IActionResult AddPlayer([FromRoute]Guid TeamId)
        {
            try
            {

                Guid playerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _teamService.AddPlayer(playerId, TeamId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpDelete("Player/{TeamId}")]
        [Authorize]
        public IActionResult DeletePlayer(Guid TeamId) 
        {
            try
            {

                Guid playerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _teamService.DeletePlayer(playerId, TeamId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet("Player/{TeamId}")]
        [Authorize]
        public IActionResult GetAllPlayers(Guid TeamId)
        {
            try
            {
                return Ok(_teamService.GetAllPlayers(TeamId));
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }


    }
}
