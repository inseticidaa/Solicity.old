using Solicity.Domain.DTOs;
namespace Solicity.Domain.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Raliza a autenticacao de um usuario previamente cadastrado na plataforma
        /// </summary>
        /// <param name="authenticateDTO">Formulario de Login da plataforma</param>
        /// <returns>DTO contendo um Token de Autorizacao</returns>
        Task<TokenDTO> Authenticate(AuthenticateDTO authenticateDTO);

        /// <summary>
        /// Registrar um novo usuario na plataforma Solicity
        /// </summary>
        /// <param name="registerDTO">Formulario de registro de novo usuario</param>
        /// <returns>DTO contendo um Token de Autorizacao</returns>
        Task<TokenDTO> Register(RegisterDTO registerDTO);
    }
}