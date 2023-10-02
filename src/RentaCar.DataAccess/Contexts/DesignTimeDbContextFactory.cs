using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace RentaCar.DataAccess.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentaCarContext>
    {
        public RentaCarContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "RentaCar.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RentaCarContext>();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);

            return new RentaCarContext(optionsBuilder.Options);
        }
    }
}
