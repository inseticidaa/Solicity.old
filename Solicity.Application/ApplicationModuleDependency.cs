using Microsoft.Extensions.DependencyInjection;
using Solicity.Application.Services;
using Solicity.Domain.Services;

namespace Solicity.Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITeamService, TeamService>();
        }
    }
}