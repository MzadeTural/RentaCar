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
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IHeroService, HeroService>();
        }
    }
}
