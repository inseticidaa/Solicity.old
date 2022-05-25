using Solicity.Domain.Entities;
using Solicity.Domain.Interfaces;

namespace Solicity.Domain.Ports.Repositories
{
    public interface ITeamRepository : IGenericRepository<Team>
    {
        Task<Team?> GetByName(string name);
        Task<IEnumerable<Team>> GetAllVisibleAsync(int page, int pageSize, int userId);
    }
}