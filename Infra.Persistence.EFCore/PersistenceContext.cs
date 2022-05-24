using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Solicity.Domain.Entities;

namespace Infra.Persistence.EFCore
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> teamMembers { get; set; }

        public PersistenceContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}