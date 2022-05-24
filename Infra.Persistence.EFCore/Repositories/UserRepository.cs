using Microsoft.EntityFrameworkCore;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System.Linq.Expressions;

namespace Infra.Persistence.EFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected PersistenceContext Context;

        public UserRepository(PersistenceContext context)
        {
            Context = context;
        }

        public async Task<int> Add(User entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CountAll()
        {
            return await Context.Set<User>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<User, bool>> predicate)
        {
            return await Context.Set<User>().CountAsync(predicate);
        }

        public async Task<User?> FirstOrDefault(Expression<Func<User, bool>> predicate)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Context.Set<User>().ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await Context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await Context.Set<User>().FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<User>> GetWhere(Expression<Func<User, bool>> predicate)
        {
            return await Context.Set<User>().Where(predicate).ToListAsync();
        }

        public Task Remove(User entity)
        {
            Context.Set<User>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task Update(User entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}