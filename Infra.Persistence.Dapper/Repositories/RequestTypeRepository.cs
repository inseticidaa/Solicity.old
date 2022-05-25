using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Dapper.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private DbSession _Session;

        public RequestTypeRepository(DbSession session)
        {
            _Session = session;
        }
        public Task<int> AddAsync(RequestType entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestType>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<RequestType?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(RequestType entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RequestType entity)
        {
            throw new NotImplementedException();
        }
    }
}
