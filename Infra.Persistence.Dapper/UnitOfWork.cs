using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _session;

        public IUserRepository Users { get; set; }
        public ITeamRepository Teams { get; set; }
        public ITeamMemberRepository TeamMembers { get; set; }
        public IRequestRepository Requests { get; set; }
        public IRequestTypeRepository RequestTypes { get; set; }

        public UnitOfWork(DbSession session,
            IUserRepository users, 
            ITeamRepository teams, 
            ITeamMemberRepository teamMembers, 
            IRequestRepository requests, 
            IRequestTypeRepository requestTypes)
        {
            _session = session;
            Users = users;
            Teams = teams;
            TeamMembers = teamMembers;
            Requests = requests;
            RequestTypes = requestTypes;
        }

        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }

        public void Dispose() => _session.Transaction?.Dispose();
    }
}