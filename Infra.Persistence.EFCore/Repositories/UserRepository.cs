using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.EFCore.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(PersistenceContext context) : base(context)
        {
        }

        public Task<User> GetByEmail(string email)
         => FirstOrDefault(u => u.Email == email);
    }
}