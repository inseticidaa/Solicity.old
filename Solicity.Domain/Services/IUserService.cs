using Solicity.Domain.DTOs.User;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync(int page, int pageSize, int userId);
    }
}