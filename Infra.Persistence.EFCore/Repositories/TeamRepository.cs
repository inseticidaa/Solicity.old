using Microsoft.EntityFrameworkCore;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System.Linq.Expressions;

namespace Infra.Persistence.EFCore.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        protected PersistenceContext Context;

        public TeamRepository(PersistenceContext context)
        {
            Context = context;
        }

        public async Task<int> Add(Team entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CountAll()
        {
            return await Context.Set<Team>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<Team, bool>> predicate)
        {
            return await Context.Set<Team>().CountAsync(predicate);
        }

        public async Task<Team?> FirstOrDefault(Expression<Func<Team, bool>> predicate)
        {
            return await Context.Set<Team>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await Context.Set<Team>().ToListAsync();
        }

        public async Task<Team?> GetById(int id)
        {
            return await Context.Teams
                .Include(x => x.Members)
                .Include(x => x.Requests)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Team?> GetByName(string name)
        {
            return await Context.Set<Team>().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Team>> GetWhere(Expression<Func<Team, bool>> predicate)
        {
            return await Context.Set<Team>().Where(predicate).ToListAsync();
        }

        public Task Remove(Team entity)
        {
            Context.Set<Team>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task Update(Team entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}