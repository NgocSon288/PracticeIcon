using Icon.DesignPattern.Common;
using Icon.DesignPattern.DataAccess;
using Icon.DesignPattern.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icon.DesignPattern.DependencyInjection
{
    public class ServiceContainer
    {
        public static ServiceProvider InitDependencyInjection()
        {
            //setup our DI
            var services = new ServiceCollection();

            // Regiser all the services in the application
            Register(services);

            var serviceprovider = services.BuildServiceProvider();

            return serviceprovider;
        } 

        private static void Register(ServiceCollection services)
        {
            // Register the services that we want to manage
            
            services.AddTransient<ApplicationDbContext>(
                options => ApplicationDbContextFactory.Init(AppSettings.DbContextSetting.ConnectionStringName));
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<AnotherProgram>();

            // End Register
        }
    }
}
