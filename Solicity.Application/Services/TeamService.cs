using FluentValidation;
using Microsoft.Extensions.Configuration;
using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Team;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Services;
using Solicity.Domain.Validators;

namespace Solicity.Application.Services
{
    public class TeamService : ITeamService
    {
        private IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task AddMember(TeamMemberDTO addMemberDTO, int userId)
        {
            try
            {
                var team = await _unitOfWork.Teams.GetByIdAsync(addMemberDTO.TeamId);
                if (team == null) throw new Exception("This team doesn't exist");

                var requesterIsMember = await _unitOfWork.TeamMembers.IsMember(team.Id, userId);
                if (requesterIsMember == null) throw new Exception("You are not a member of the group");

                var user = await _unitOfWork.Users.GetByIdAsync(addMemberDTO.UserId);
                if (user == null) throw new Exception("This user does not exist");

                var IsMember = await _unitOfWork.TeamMembers.IsMember(team.Id, addMemberDTO.UserId);
                if (IsMember) throw new Exception("This user is already a team member");

                var newTeamMember = new TeamMember
                {
                    TeamId = team.Id,
                    UserId = user.Id,
                };

                await _unitOfWork.TeamMembers.AddAsync(newTeamMember);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> AddProject(NewProjectDTO newProject, int teamId, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddRequest(NewRequestDTO newRequest, int teamId, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null) throw new Exception("This User does not exist");
                if (!user.Enabled) throw new Exception("This User not enabled");

                var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
                if (team == null) throw new Exception("This Team doesn't exist");
                if (!team.Enabled) throw new Exception("This Team not enabled");

                if (!team.Public)
                {
                    var IsMember = await _unitOfWork.TeamMembers.IsMember(team.Id, userId);
                    if (!IsMember) throw new UnauthorizedAccessException("You are not a member of the group");
                }

                var request = new Request {
                    TeamId = team.Id,
                    AuthorId = user.Id,
                    RequestTypeId = newRequest.RequestTypeId,
                    Title = newRequest.Title,
                    Description= newRequest.Description,
                    CreatedAt = DateTime.Now,
                    UdpatedAt = DateTime.Now,
                };

                var validator = new RequestValidator();
                await validator.ValidateAndThrowAsync(request);

                var requestType = await _unitOfWork.RequestTypes.GetByIdAsync(request.RequestTypeId);
                if (requestType == null) throw new Exception("This Request Type doesn't exist");
                if (!requestType.Enabled) throw new Exception("This Request Type not enabled");

                var request_id = await _unitOfWork.Requests.AddAsync(request);

                return request_id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> Create(NewTeamDTO newTeamDTO, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);

                if (user is null) throw new Exception("This User does not exist");
                if (!user.Enabled) throw new Exception("This User not enabled");
                if (!user.IsAdmin) throw new Exception("This User Unauthorized");

                var team = await _unitOfWork.Teams.GetByName(newTeamDTO.Name);
                if (team is not null) throw new Exception("A team with the same name has already been created");

                var _team = new Team
                {
                    Name = newTeamDTO.Name,
                    Description = newTeamDTO.Description,
                    Public = newTeamDTO.Public,
                    Enabled = true,
                    CreatedAt = DateTime.Now,
                    UdpatedAt = DateTime.Now,
                };

                var validador = new TeamValidator();
                await validador.ValidateAndThrowAsync(_team);

                var teamId = await _unitOfWork.Teams.AddAsync(_team);

                var tm = new TeamMember
                {
                    TeamId = teamId,
                    UserId = user.Id,
                    CreatedAt = DateTime.Now,
                    UdpatedAt = DateTime.Now,
                };

                await _unitOfWork.TeamMembers.AddAsync(tm);

                return teamId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int teamId, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);

                if (user is null) throw new Exception("This User does not exist");
                if (!user.Enabled) throw new Exception("This User not enabled");
                if (!user.IsAdmin) throw new Exception("This User Unauthorized");

                var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
                if (team == null) throw new Exception("This Team doesn't exist");
                if (!team.Enabled) throw new Exception("This Team not enabled");

                await _unitOfWork.Teams.RemoveAsync(team);

                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Edit(int teamId, EditTeamDTO team, int userId)
        {
            try
            {
                var _team = await _unitOfWork.Teams.GetByIdAsync(teamId);
                if (_team == null) throw new Exception("This Team doesn't exist");

                var isMember = await _unitOfWork.TeamMembers.IsMember(_team.Id, userId);
                if (!isMember) throw new Exception("You are not a member of the group");

                _team.Name = team.Name;
                _team.Description = team.Description;
                _team.Enabled = team.Enabled;
                _team.Public = team.Public;

                await _unitOfWork.Teams.UpdateAsync(_team);

                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task EditProject(EditProjectDTO editProject, int projectId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task EditRequest(EditRequestDTO editRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamDTO> Find(int teamId, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null) throw new Exception("This User does not exist");
                if (!user.Enabled) throw new Exception("This User not enabled");

                var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
                if (team == null) throw new Exception("This Team doesn't exist");

                if (team.Public)
                {
                    var isMember = await _unitOfWork.TeamMembers.IsMember(team.Id, userId);
                    if (isMember) throw new Exception("This team is private");
                }

                return (TeamDTO)team;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TeamDTO>> GetAllAsync(int page, int pageSize, int userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(userId);
                if (user == null) throw new Exception("This User does not exist");
                if (!user.Enabled) throw new Exception("This User not enabled");

                var teams = await _unitOfWork.Teams.GetAllVisibleAsync(page, pageSize, user.Id);

                return teams.Select(x => (TeamDTO)x);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetMembers(int teamId, int userId)
        {
            try
            {
                var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
                if (team == null) throw new Exception("This Team doesn't exist");

                if (!team.Public)
                {
                    var isMember = await _unitOfWork.TeamMembers.IsMember(team.Id, userId);
                    if (!isMember) throw new Exception("You are not a member of the group");
                }

                var teamMembers = await _unitOfWork.TeamMembers.GetMembersAsync(teamId);

                return teamMembers.Select(x => (UserDTO)x.User);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public Task RemoveMember(TeamMemberDTO addMemberDTO, int userId)
        {
            throw new NotImplementedException();
        }
    }
}