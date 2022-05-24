using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IUserService
    {
        Task<User> Create(User newUser);
    }
}