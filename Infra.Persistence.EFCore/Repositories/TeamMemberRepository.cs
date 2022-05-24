using Microsoft.EntityFrameworkCore;
using Solicity.Domain.Entities;
using Solicity.Domain.Interfaces;
using Solicity.Domain.Ports.Repositories;
using System.Linq.Expressions;

namespace Infra.Persistence.EFCore.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        protected PersistenceContext Context;

        public TeamMemberRepository(PersistenceContext context)
        {
            Context = context;
        }

        public async Task<int> Add(TeamMember entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CountAll()
        {
            return await Context.Set<TeamMember>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<TeamMember, bool>> predicate)
        {
            return await Context.Set<TeamMember>().CountAsync(predicate);
        }

        public async Task<TeamMember?> FirstOrDefault(Expression<Func<TeamMember, bool>> predicate)
        {
            return await Context.Set<TeamMember>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TeamMember>> GetAll()
        {
            return await Context.Set<TeamMember>().ToListAsync();
        }

        public async Task<TeamMember?> GetById(int id)
        {
            return await Context.Set<TeamMember>().FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<TeamMember>> GetWhere(Expression<Func<TeamMember, bool>> predicate)
        {
            return await Context.Set<TeamMember>().Include(x => x.User).Where(predicate).ToListAsync();
        }

        public Task Remove(TeamMember entity)
        {
            Context.Set<TeamMember>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task Update(TeamMember entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}