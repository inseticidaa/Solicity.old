using Microsoft.EntityFrameworkCore;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.EFCore.Repositories
{
    public class RequestRepository: IRequestRepository
    {
        protected PersistenceContext Context;

        public RequestRepository(PersistenceContext context)
        {
            Context = context;
        }

        public async Task<int> Add(Request entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CountAll()
        {
            return await Context.Set<Request>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<Request, bool>> predicate)
        {
            return await Context.Set<Request>().CountAsync(predicate);
        }

        public async Task<Request?> FirstOrDefault(Expression<Func<Request, bool>> predicate)
        {
            return await Context.Set<Request>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Request>> GetAll()
        {
            return await Context.Set<Request>().ToListAsync();
        }

        public async Task<Request?> GetById(int id)
        {
            return await Context.Set<Request>().Include(x => x.RequestType).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Request>> GetWhere(Expression<Func<Request, bool>> predicate)
        {
            return await Context.Set<Request>().Where(predicate).ToListAsync();
        }

        public Task Remove(Request entity)
        {
            Context.Set<Request>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task Update(Request entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}
