using Solicity.Domain.DTOs;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(string email, string password);

        Task<TokenDTO> Register(User newUser);
    }
}