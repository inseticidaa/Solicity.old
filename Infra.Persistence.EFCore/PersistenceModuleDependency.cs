using Infra.Persistence.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Solicity.Domain.Interfaces;
using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;

namespace Infra.Persistence.EFCore
{
    public static class PersistenceModuleDependency
    {
        public static void AddPersistenceModule(this IServiceCollection services)
        {
            services.AddDbContext<PersistenceContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}