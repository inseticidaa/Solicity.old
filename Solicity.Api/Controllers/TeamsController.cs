using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Team;
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

        #region [Team]

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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] NewTeamDTO model)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                var teamId = await _teamService.Create(model, requesterId);

                return CreatedAtAction(nameof(GetById), new { id = teamId }, new { teamId = teamId });
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

        #endregion [Team]

        #region [Members]

        [HttpPost("{teamId}/Members/{userID}")]
        [Authorize]
        public async Task<IActionResult> AddMember([FromRoute] int teamId, [FromRoute] int userId)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                await _teamService.AddMember(new TeamMemberDTO { TeamId = teamId, UserId = userId }, requesterId);

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

        [HttpDelete("{teamId}/Members/{userID}")]
        [Authorize]
        public async Task<IActionResult> RemoveMember([FromRoute] int teamId, [FromRoute] int userId)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                await _teamService.RemoveMember(new TeamMemberDTO { TeamId = teamId, UserId = userId }, requesterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        #endregion [Members]

        #region [Requests]

        [HttpPost("{teamId}/Requests/")]
        [Authorize]
        public async Task<IActionResult> AddRequest([FromRoute] int teamId, [FromBody] NewRequestDTO newRequest)
        {
            try
            {
                var requesterId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

                await _teamService.AddRequest(newRequest, teamId, requesterId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{teamId}/Requests")]
        public void GetRequest([FromRoute] int teamId)
        {
        }

        #endregion [Requests]
    }
}