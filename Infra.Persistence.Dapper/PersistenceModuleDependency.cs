using Infra.Persistence.Dapper.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.Dapper
{
    public static class PersistenceModuleDependency
    {
        public static void AddPersistenceModule(this IServiceCollection services)
        {
            services.AddScoped<DbSession>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
