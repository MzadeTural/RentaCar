using Microsoft.Extensions.DependencyInjection;
using RentaCar.Business.Services.Implementations;
using RentaCar.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Business.Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {


            services.AddScoped<ICarService, CarService>();
           
        }
    }
}
