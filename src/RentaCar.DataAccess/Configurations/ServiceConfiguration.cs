using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Configurations
{
    public class ServiceConfiguration
    {

        public static string ConnectionString()
        {

            ConfigurationManager manager = new ConfigurationManager();
            manager.SetBasePath(Directory.GetCurrentDirectory() + "../../../RentaCar.Api");
            manager.AddJsonFile("appsettings.json");
            return manager.GetConnectionString("Default");
        }
    }
}
