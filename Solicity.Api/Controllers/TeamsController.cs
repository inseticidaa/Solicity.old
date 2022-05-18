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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
                    Description = model.Description,
                    AuthorId = int.Parse(idClaim.Value),
                };

                var team = await _teamService.Create(newTeam);

                return CreatedAtAction(nameof(Get), new { Id = team.Id }, team);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [Authorize("User")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
