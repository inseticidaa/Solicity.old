using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository users,
            ITeamRepository teams,
            ITeamMemberRepository teamMembers)
        {
            Users = users;
            Teams = teams;
            TeamMembers = teamMembers;
        }

        public IUserRepository Users { get; set; }
        public ITeamRepository Teams { get; set; }
        public ITeamMemberRepository TeamMembers { get; set; }
    }
}