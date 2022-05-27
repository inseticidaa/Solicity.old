using Solicity.Domain.DTOs;
using Solicity.Domain.DTOs.Team;
using Solicity.Domain.DTOs.User;

namespace Solicity.Domain.Services
{
    public interface ITeamService
    {
        /// <summary>
        /// Busca todos os times que são visiveis para um determinado usuario
        /// </summary>
        /// <param name="page">Pagina de indexacao</param>
        /// <param name="pageSize">Tamanho da pagina que esta sendo buscada</param>
        /// <param name="userId">Usuario que esta realizando a busca</param>
        /// <returns></returns>
        Task<IEnumerable<TeamDTO>> GetAllAsync(int page, int pageSize, int userId);

        /// <summary>
        /// Cria um novo time na plataforma Solicity
        /// </summary>
        /// <param name="newTeamDTO">Formulario de criacao do novo time</param>
        /// <param name="userId">Usuario que esta criando o time</param>
        /// <returns>Id do time que foi criado</returns>
        Task<int> Create(NewTeamDTO newTeamDTO, int userId);

        /// <summary>
        /// Edita as informacos de uma determinada equipe
        /// </summary>
        /// <param name="teamId">Id do time que sera alterado</param>
        /// <param name="editTeamDTO">Formulario de alteracao</param>
        /// <param name="userId">Usuario que esta tentando realizar a alteracao</param>
        /// <returns></returns>
        Task Edit(int teamId, EditTeamDTO editTeamDTO, int userId);

        /// <summary>
        /// Exclui um time de plataforma Solicity
        /// </summary>
        /// <param name="teamId">Id do time que sera excluido</param>
        /// <param name="userId">Id do usuario que esta excluindo</param>
        /// <returns></returns>
        Task Delete(int teamId, int userId);

        /// <summary>
        /// Procura um time baseado no seu Id
        /// </summary>
        /// <param name="teamId">Id do time que esta sendo produrado</param>
        /// <param name="userId">Id do usuario que esta fazendo a pesquisa</param>
        /// <returns>DTO contendo as informacoes do time</returns>
        Task<TeamDTO> Find(int teamId, int userId);

        /// <summary>
        /// Busca todos os membro de um determinado time
        /// </summary>
        /// <param name="teamId">Id do time</param>
        /// <param name="userId">Id do usuario que esta realizando a pesquisa</param>
        /// <returns></returns>
        Task<IEnumerable<UserDTO>> GetMembers(int teamId, int userId);

        /// <summary>
        /// Adiciona um novo membro a um determinado time
        /// </summary>
        /// <param name="addMemberDTO">Formulario de Adicao de novo membro</param>
        /// <param name="userId">Id do usuario que esta realizando a acao</param>
        /// <returns></returns>
        Task AddMember(TeamMemberDTO TeamMemberDTO, int userId);

        /// <summary>
        /// Remove um determinado usuario de um determinado time
        /// </summary>
        /// <param name="addMemberDTO">F</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task RemoveMember(TeamMemberDTO TeamMemberDTO, int userId);

        /// <summary>
        /// Adiciona uma solicitacao a um determinado time.
        /// </summary>
        /// <param name="newRequest">Formulario para criacao de Solicitacao</param>
        /// <param name="teamId">Time que a solicitacao sera atribuida</param>
        /// <param name="userId">Usuario que esta criando a solicitacao</param>
        /// <returns></returns>
        Task<int> AddRequest(NewRequestDTO newRequest, int teamId, int userId);
    }
}