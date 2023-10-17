using Microsoft.Extensions.DependencyInjection;
using RentaCar.Business.Services.Implementations;
using RentaCar.Business.Services.Interfaces;

namespace RentaCar.Business.Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {


            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ITokenHandler, TokenHandler>();

        }
    }
}
