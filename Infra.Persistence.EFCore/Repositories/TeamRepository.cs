using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.EFCore.Repositories
{
    public class TeamRepository : EfRepository<Team>, ITeamRepository
    {
        public TeamRepository(PersistenceContext context) : base(context)
        {
        }

        public Task<Team> GetByName(string name)
            => FirstOrDefault(u => u.Name == name);
    }
}