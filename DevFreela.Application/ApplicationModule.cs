using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using MediatR;
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
                    .AddService()
                    .AddHandlers()
                    ;
            return services;
        }


        private static IServiceCollection AddService(this IServiceCollection services ) 
        {
            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
            return services;
        }




    }   
}
