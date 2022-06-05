using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Infra.Persistence.Dapper.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private DbSession _Session;

        public TeamRepository(DbSession session)
        {
            _Session = session;
        }
        public async Task<int> AddAsync(Team entity)
        {
            var query = @"
            INSERT INTO [dbo].[TB_TEAMS]
                ([Name]
                ,[Description]
                ,[Enabled]
                ,[Public]
                ,[CreatedAt]
                ,[UdpatedAt])
            VALUES
                (@Name
                ,@Description
                ,@Enabled
                ,@Public
                ,@CreatedAt
                ,@UdpatedAt);
            SELECT SCOPE_IDENTITY();";

            var teamId = await _Session.Connection.QueryFirstOrDefaultAsync<int>(query, entity, _Session.Transaction);
            return teamId;
        }

        public async Task<IEnumerable<Team>> GetAllAsync(int page, int pageSize)
        {
            var query = @"
            SELECT *
            FROM TB_TEAMS
            WHERE DeletedAt IS NULL
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

            var result = await _Session.Connection.QueryAsync<Team>(
                query,
                new
                {
                    Offset = (page - 1) * pageSize,
                    PageSize = pageSize
                }
                , _Session.Transaction
            );

            return result;
        }

        public async Task<IEnumerable<Team>> GetAllVisibleAsync(int page, int pageSize, int userId)
        {
            var query = @"
            ( SELECT * FROM TB_TEAMS WHERE [Public] = 1 )
            UNION
            (
	            SELECT t.* FROM TB_TEAMS t
	            INNER JOIN TB_TEAMS_MEMBERS tm ON tm.TeamId = t.Id
	            INNER JOIN TB_USERS u ON u.Id = tm.UserId
	            WHERE [t].[Public] = 0 AND (tm.UserId = @UserId 
                OR (SELECT IsAdmin FROM TB_USERS WHERE Id = @UserId) = 1)
            )
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";


            var result = await _Session.Connection.QueryAsync<Team>(
                query,
                new
                {
                    Offset = (page - 1) * pageSize,
                    PageSize = pageSize,
                    UserId = userId
                }
                , _Session.Transaction
            );

            return result;
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM TB_TEAMS WHERE Id = @Id AND DeletedAt IS NULL";
            var result = await _Session.Connection.QueryFirstOrDefaultAsync<Team>(query, new { Id = id }, _Session.Transaction);
            return result;
        }

        public async Task<Team?> GetByName(string name)
        {
            var query = @"SELECT * FROM TB_TEAMS WHERE Name = @Name AND DeletedAt IS NULL";
            var result = await _Session.Connection.QueryFirstOrDefaultAsync<Team>(query, new { Name = name }, _Session.Transaction);
            return result;
        }

        public async Task RemoveAsync(Team entity)
        {
            var query = @"UPDATE TB_TEAMS SET DeletedAt = GETDATE() WHERE Id = @Id AND DeletedAt IS NULL;";
            await _Session.Connection.ExecuteAsync(query, entity, _Session.Transaction);
        }

        public async Task UpdateAsync(Team entity)
        {
            var query = @"
            UPDATE [dbo].[TB_TEAMS]
               SET [Name] = @Name
                  ,[Description] = @Description
                  ,[Enabled] = @Enabled
                  ,[Public] = @Public
                  ,[CreatedAt] = @CreatedAt
                  ,[UdpatedAt] = @UdpatedAt
             WHERE Id = @Id";

            await _Session.Connection.ExecuteAsync(query, entity, _Session.Transaction);
        }
    }
}
