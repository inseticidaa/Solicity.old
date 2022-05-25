using Dapper;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.Dapper.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSession _Session;

        public UserRepository(DbSession session)
        {
            _Session = session;
        }

        public Task<int> AddAsync(User entity)
        {
            var query = @"
            INSERT INTO [dbo].[TB_USERS]
                ([FirstName]
                ,[LastName]
                ,[Email]
                ,[Hash]
                ,[Enabled]
                ,[IsAdmin]
                ,[CreatedAt]
                ,[UdpatedAt])
            VALUES
                (@FirstName
                ,@LastName
                ,@Email
                ,@Hash
                ,@Enabled
                ,@IsAdmin
                ,@CreatedAt
                ,@UdpatedAt);
            SELECT SCOPE_IDENTITY();";

            var result = _Session.Connection.QueryFirstOrDefaultAsync<int>(query, entity);
            return result;
        }

        public async Task<IEnumerable<User>> GetAllAsync(int page, int pageSize)
        {
            var query = @"
            SELECT *
            FROM TB_USERS
            WHERE DeletedAt IS NULL
            ORDER BY Id
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

            var result = await _Session.Connection.QueryAsync<User>(
                query, 
                new
                {
                    Offset = (page - 1) * pageSize,
                    PageSize = pageSize
                }
            );

            return result;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var query = @"SELECT * FROM TB_USERS WHERE Email = @Email AND DeletedAt IS NULL";
            var result = await _Session.Connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email });
            return result;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM TB_USERS WHERE Id = @Id AND DeletedAt IS NULL";
            var result = await _Session.Connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
            return result;
        }

        public async Task RemoveAsync(User entity)
        {
            var query = @"UPDATE TB_USERS SET DeletedAt = GETDATE() WHERE Id = @Id AND DeletedAt IS NULL;";
            await _Session.Connection.ExecuteAsync(query, entity);
        }

        public async Task UpdateAsync(User entity)
        {
            var query = @"
            UPDATE [dbo].[TB_USERS]
               SET [FirstName] = @FirstName
                  ,[LastName] = @LastName
                  ,[Email] = @Email
                  ,[Hash] = @Hash
                  ,[Enabled] = @Enabled
                  ,[IsAdmin] = @IsAdmin
                  ,[CreatedAt] = @CreatedAt
                  ,[UdpatedAt] = @UdpatedAt
             WHERE Id = @Id";

            await _Session.Connection.ExecuteAsync(query, entity);
        }
    }
}