using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using AutoMapper;
using application.behaviors;

namespace application
{
    public static class ApplicationRegistration
    {
       public static void AddApplication(this IServiceCollection services){

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
        
    }
}