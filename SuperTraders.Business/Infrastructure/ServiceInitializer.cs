using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperTraders.Business.Interfaces;
using SuperTraders.DAL.Repository.Implementation.EntityFramework;
using SuperTraders.DAL.Repository.Interfaces.EntityFramework;

namespace SuperTraders.Business.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyTradeApp");
            services.AddDbContext<EFDbContext>(opt => opt.UseSqlServer(connectionString));
        }

        public static void AddServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<ITradeRepository,TradeRepository>();
            services.AddScoped<IShareRepository, ShareRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();


            //Add services that inherited from IServiceBase with Scoped lifetime 
            var baseType = typeof(IServiceBase);
            var assembly = baseType.Assembly;
            var allTypes = assembly.GetTypes();
            var iFaces = allTypes.Where(q => baseType.IsAssignableFrom(q) && q.IsInterface && q != baseType);
            foreach (var iFace in iFaces)
            {
                var implementedClass = allTypes.Where(q => q.IsClass && iFace.IsAssignableFrom(q)).FirstOrDefault();
                if (implementedClass != null)
                {
                    services.AddScoped(iFace, implementedClass);
                }
                else
                {
                    throw new System.Exception("There is no implementation class for " + iFace.Name);
                }

            }


        }
    }
}
