using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solicity.Domain.DTOs.Team;
using Solicity.Domain.Entities;
using Solicity.Domain.Services;

namespace Solicity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] NewTeamDTO model)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var teamId = await _teamService.Create(model, requesterId);

                return CreatedAtAction(nameof(GetById), new {id = teamId}, new { teamId = teamId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var team = await _teamService.Find(id, requesterId);

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var team = await _teamService.GetAllAsync(page, pageSize, requesterId);

                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] EditTeamDTO model)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                await _teamService.Edit(id, model, requesterId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                await _teamService.Delete(id, requesterId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{teamId}/Members")]
        [Authorize]
        public async Task<IActionResult> GetMembers([FromRoute] int teamId)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var members = await _teamService.GetMembers(teamId, requesterId);
                
                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}