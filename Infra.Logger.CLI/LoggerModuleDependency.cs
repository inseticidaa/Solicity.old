using Microsoft.Extensions.DependencyInjection;
using Solicity.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Logger.CLI
{
    public static class LoggerModuleDependency
    {
        public static void AddLoggerModule(this IServiceCollection services)
        {
            services.AddTransient<ILogger, Logger>();
        }
    }
}
