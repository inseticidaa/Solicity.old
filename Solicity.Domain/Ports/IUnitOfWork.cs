using Solicity.Domain.Ports.Repositories;

namespace Solicity.Domain.Ports
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; set; }
        ITeamRepository Teams { get; set; }
        ITeamMemberRepository TeamMembers { get; set; }
    }
}