using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Auth;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> Login(LoginDTO loginDTO);

        Task<TokenDTO> Register(RegisterDTO registerDTO);
    }
}