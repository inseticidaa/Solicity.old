using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync(int page, int pageSize, int userId);
    }
}