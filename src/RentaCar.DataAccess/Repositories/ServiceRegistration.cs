using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentaCar.Core.Entities;
using RentaCar.DataAccess.Configurations;
using RentaCar.DataAccess.Contexts;
using RentaCar.DataAccess.Repositories.Implementations;
using RentaCar.DataAccess.Repositories.Interfaces;

namespace RentaCar.DataAccess.Repositories
{
    public static class ServiceRegistration
    {

        public static void AddDataAccesServices(this IServiceCollection services)
        {
            services.AddDbContext<RentaCarContext>(opt =>
            {
                opt.UseSqlServer(ServiceConfiguration.ConnectionString());
            }).AddIdentity<AppUser,IdentityRole<Guid>>(x =>
            {
                x.Password.RequiredLength = 5;
                //  x.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
                x.SignIn.RequireConfirmedEmail = true;
                x.User.RequireUniqueEmail = true;
                //todo we will change here or add somethings
            }).
            AddEntityFrameworkStores<RentaCarContext>().AddDefaultTokenProviders();

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

        }

      }
}
