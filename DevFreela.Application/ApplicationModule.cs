using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                    .AddService();
            return services;
        }


        private static IServiceCollection AddService(this IServiceCollection services ) 
        {
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }   
}
