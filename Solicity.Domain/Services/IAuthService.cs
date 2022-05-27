using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Auth;
using Solicity.Domain.Entities;

namespace Solicity.Domain.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Raliza a autenticacao de um usuario previamente cadastrado na plataforma
        /// </summary>
        /// <param name="loginDTO">Formulario de Login da plataforma</param>
        /// <returns>DTO contendo um Token de Autorizacao</returns>
        Task<TokenDTO> Login(LoginDTO loginDTO);

        /// <summary>
        /// Registrar um novo usuario na plataforma Solicity
        /// </summary>
        /// <param name="registerDTO">Formulario de registro de novo usuario</param>
        /// <returns>DTO contendo um Token de Autorizacao</returns>
        Task<TokenDTO> Register(RegisterDTO registerDTO);
    }
}