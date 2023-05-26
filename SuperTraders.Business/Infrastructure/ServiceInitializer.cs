using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperTraders.DAL.Repository.Implementation.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Business.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MyTradeApp");
            services.AddDbContext<EFDbContext>(opt => opt.UseSqlServer(connectionString));
        }
    }
}
