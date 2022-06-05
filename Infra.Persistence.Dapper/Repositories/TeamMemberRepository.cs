using Dapper;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.Dapper.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private DbSession _Session;

        public TeamMemberRepository(DbSession session)
        {
            _Session = session;
        }

        public async Task<int> AddAsync(TeamMember entity)
        {
            var query = @"
            INSERT INTO [dbo].[TB_TEAMS_MEMBERS]
                ([UserId]
                ,[TeamId]
                ,[CreatedAt]
                ,[UdpatedAt])
            VALUES
                (@UserId
                ,@TeamId
                ,@CreatedAt
                ,@UdpatedAt);
            SELECT SCOPE_IDENTITY();";

            var teamMemberId = await _Session.Connection.QueryFirstOrDefaultAsync<int>(query, entity, _Session.Transaction);
            return teamMemberId;
        }

        public async Task<IEnumerable<TeamMember>> GetAllAsync(int page, int pageSize)
        {
            var query = @"
            SELECT *
            FROM [dbo].[TB_TEAMS_MEMBERS] tm
            LEFT JOIN TB_USERS u ON u.Id = tm.UserId
            WHERE tm.DeletedAt IS NULL AND u.DeletedAt IS NULL
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

            var result = await _Session.Connection.QueryAsync<TeamMember, User, TeamMember>(
                query,
                (tm, user) => { tm.User = user; return tm; },
                new
                {
                    Offset = (page - 1) * pageSize,
                    PageSize = pageSize
                }
                , _Session.Transaction
            );

            return result;
        }

        public async Task<TeamMember?> GetByIdAsync(int id)
        {
            var query = @"
            SELECT * FROM TB_TEAMS_MEMBERS tm
            LEFT JOIN TB_USERS u ON u.Id = tm.UserId
            WHERE tm.Id = @Id AND (tm.DeletedAt IS NULL AND u.DeletedAt IS NULL);";

            var result = await _Session.Connection.QueryAsync<TeamMember, User, TeamMember>(query, (tm, user) => { tm.User = user; return tm; }, new { Id = id }, _Session.Transaction);

            var teamMember = result.ToList().FirstOrDefault();

            return teamMember;
        }

        public async Task<IEnumerable<TeamMember>> GetMembersAsync(int teamId)
        {
            var query = @"
            SELECT * FROM TB_TEAMS_MEMBERS tm
            LEFT JOIN TB_USERS u ON u.Id = tm.UserId
            WHERE tm.TeamId = @TeamId AND (tm.DeletedAt IS NULL AND u.DeletedAt IS NULL);";

            var result = await _Session.Connection.QueryAsync<TeamMember, User, TeamMember>(query, (tm, user) => { tm.User = user; return tm; }, new { TeamId = teamId }, _Session.Transaction);

            return result;
        }

        public async Task<bool> IsMember(int teamId, int userId)
        {
            var query = @"
            SELECT CAST(
                CASE WHEN EXISTS(SELECT * FROM TB_TEAMS_MEMBERS WHERE TeamId = @TeamId and UserId = @UserId AND DeletedAt IS NULL) THEN 1
                    ELSE 0
                END
            AS BIT)";

            var result = await _Session.Connection.QueryFirstOrDefaultAsync<bool>(query, new { TeamId = teamId, UserId = userId }, _Session.Transaction);

            return result == null ? false : result;
        }

        public async Task RemoveAsync(TeamMember entity)
        {
            var query = @"UPDATE TB_TEAMS_MEMBERS SET DeletedAt = GETDATE() WHERE TeamId = @TeamId AND UserId = @UserId;";
            await _Session.Connection.ExecuteAsync(query, entity, _Session.Transaction);
        }

        public Task UpdateAsync(TeamMember entity)
        {
            throw new NotImplementedException();
        }
    }
}