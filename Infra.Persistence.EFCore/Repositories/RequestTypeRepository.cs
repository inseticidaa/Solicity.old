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
    public class RequestTypeRepository : IRequestTypeRepository
    {
        protected PersistenceContext Context;

        public RequestTypeRepository(PersistenceContext context)
        {
            Context = context;
        }

        public async Task<int> Add(RequestType entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> CountAll()
        {
            return await Context.Set<RequestType>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<RequestType, bool>> predicate)
        {
            return await Context.Set<RequestType>().CountAsync(predicate);
        }

        public async Task<RequestType?> FirstOrDefault(Expression<Func<RequestType, bool>> predicate)
        {
            return await Context.Set<RequestType>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<RequestType>> GetAll()
        {
            return await Context.Set<RequestType>().ToListAsync();
        }

        public async Task<RequestType?> GetById(int id)
        {
            return await Context.Set<RequestType>().FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<RequestType>> GetWhere(Expression<Func<RequestType, bool>> predicate)
        {
            return await Context.Set<RequestType>().Where(predicate).ToListAsync();
        }

        public Task Remove(RequestType entity)
        {
            Context.Set<RequestType>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task Update(RequestType entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
    }
}
