using FluentValidation;
using Microsoft.Extensions.Configuration;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;
using Solicity.Domain.Validators;

namespace Solicity.Application.Services
{
    public class TeamService : ITeamService
    {
        #region [Props]

        private IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public TeamService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        #endregion [Props]

        #region [Methods}

        public async Task<int> Create(Team newTeam, int requesterId)
        {
            try
            {
                var validador = new TeamValidator();

                validador.ValidateAndThrow(newTeam);

                var count = await _unitOfWork.Teams.CountWhere(t => t.Name == newTeam.Name);

                if (count > 0)
                {
                    throw new Exception("There is already a team with that name");
                }

                newTeam.Members.Add(new TeamMember
                {
                    UserId = requesterId,
                });

                var teamId = await _unitOfWork.Teams.Add(newTeam);

                return teamId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddMember(int teamId, int userId, int requesterId)
        {
            try
            {
                var team = await _unitOfWork.Teams.GetById(teamId);
                if (team == null) throw new Exception("This team doesn't exist");

                if (!team.Members.Where(t => t.UserId == requesterId).Any())
                {
                    throw new Exception("You are not a member of the group");
                }

                var user = await _unitOfWork.Users.GetById(userId);
                if (user == null) throw new Exception("This user does not exist");

                if (team.Members.Where(t => t.UserId == userId).Any())
                {
                    throw new Exception("This user is already a team member");
                }

                team.Members.Add(new TeamMember
                {
                    TeamId = team.Id,
                    UserId = user.Id
                });

                await _unitOfWork.Teams.Update(team);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TeamMember>> GetMembers(int teamId)
        {
            try
            {
                var results = await _unitOfWork.TeamMembers.GetWhere(tm => tm.TeamId == teamId);
                return results.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Methods}
    }
}