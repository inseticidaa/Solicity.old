using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository users,
            ITeamRepository teams,
            ITeamMemberRepository teamMembers,
            IRequestRepository requests,
            IRequestTypeRepository requestTypes
)
        {
            Users = users;
            Teams = teams;
            TeamMembers = teamMembers;
            Requests = requests;
            RequestTypes = requestTypes;
        }

        public IUserRepository Users { get; set; }
        public ITeamRepository Teams { get; set; }
        public ITeamMemberRepository TeamMembers { get; set; }
        public IRequestRepository Requests { get; set; }
        public IRequestTypeRepository RequestTypes { get; set; }
    }
}