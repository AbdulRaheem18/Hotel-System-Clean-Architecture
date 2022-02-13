using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
//using application.Interfaces;
using infrastructure;
using infrastructure.Persistence;
using application.Repositories;


//using infrastructure.Services;

namespace infrastructure
{
    public static class InfrastructureRegistration
    {
       public static void AddInfrastructure(this IServiceCollection services){
            services
            .AddScoped<IHotelRepository, HotelRepository>();
            
        }
        
    }
}