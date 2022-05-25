using Solicity.Domain.DTOs.Team;
using Solicity.Domain.DTOs.User;

namespace Solicity.Domain.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetAllAsync(int page, int pageSize, int userId);
        Task<int> Create(NewTeamDTO newTeamDTO, int userId);
        Task Edit(int teamId, EditTeamDTO editTeamDTO, int userId);
        Task Delete(int teamId, int userId);
        Task<TeamDTO> Find(int teamId, int userId);
        Task<IEnumerable<UserDTO>> GetMembers(int teamId, int userId);
        Task AddMember(AddMemberDTO addMemberDTO, int userId);
    }
}