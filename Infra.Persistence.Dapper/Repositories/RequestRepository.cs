using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Dapper.Repositories
{
    public class RequestRepository : IRequestRepository
    {

        private DbSession _Session;

        public RequestRepository(DbSession session)
        {
            _Session = session;
        }

        public Task<int> AddAsync(Request entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Request?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Request entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
