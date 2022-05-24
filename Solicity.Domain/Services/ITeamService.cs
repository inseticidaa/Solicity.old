using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface ITeamService
    {
        Task<int> Create(Team newTeam, int requesterId);
        Task AddMember(int teamId, int userId, int requesterId);
        Task<ICollection<TeamMember>> GetMembers(int teamId);
    }
}