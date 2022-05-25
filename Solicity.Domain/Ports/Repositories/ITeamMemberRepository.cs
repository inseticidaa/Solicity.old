using Solicity.Domain.Entities;
using Solicity.Domain.Interfaces;

namespace Solicity.Domain.Ports.Repositories
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        Task<IEnumerable<TeamMember>> GetMembersAsync(int teamId);
        Task<bool> IsMember(int teamId, int userId);
    }
}