using Microsoft.Extensions.DependencyInjection;
using Solicity.Domain.Entities;
using Solicity.Domain.Ports;
using Solicity.Domain.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistence.EFCore
{
    public static class PersistenceModuleDependency
    {
        public static void AddPersistenceModule(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, IUserRepository>();
        }
    }
}
