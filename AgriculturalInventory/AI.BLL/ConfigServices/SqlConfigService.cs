using AI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AI.BLL.ConfigServices
{
    public static class SqlConfigService
    {
        public static IServiceCollection RegisterSqlServer(this IServiceCollection services, string dbConnection)
        {

            //Core Database Tables
            services.AddDbContext<AIContext>(options => options.UseSqlServer(dbConnection));

            return services;
        }
    }
}
