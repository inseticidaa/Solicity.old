using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solicity.Api.Models.Teams;
using Solicity.Domain.Entities;
using Solicity.Domain.Services;
using System.Security.Claims;

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
        [Authorize("Admin")]
        public async Task<IActionResult> Post([FromBody] CreateTeamRequest model)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;

                var idClaim = claim
                    .Where(x => x.Type == "Id")
                    .FirstOrDefault();

                var newTeam = new Team
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _teamService.Create(newTeam, int.Parse(idClaim.Value));

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("{teamId}/AddMember")]
        [Authorize]
        public async Task<IActionResult> AddMember([FromBody] int userId, [FromRoute] int teamId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;

                var idClaim = claim
                    .Where(x => x.Type == "Id")
                    .FirstOrDefault();

                await _teamService.AddMember(teamId, userId,int.Parse(idClaim.Value));

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{teamId}/Members")]
        [Authorize]
        public async Task<IActionResult> Members([FromRoute] int teamId)
        {
            try
            {
                var result = await _teamService.GetMembers(teamId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}