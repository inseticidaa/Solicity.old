﻿using Infra.Persistence.EFCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Solicity.Domain.Entities;
using Solicity.Domain.Interfaces;
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
            services.AddDbContext<PersistenceContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfRepository<>));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ICardRepository, CardRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
