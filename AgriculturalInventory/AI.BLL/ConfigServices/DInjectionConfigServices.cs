using AI.BLL.Interfaces;
using AI.BLL.Repository;
using AI.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AI.BLL.ConfigServices
{
    public static class DInjectionConfigServices
    {
        public static IServiceCollection RegisterDInjections(this IServiceCollection services)
        {
            //Methods
            services.AddTransient<AIContext>();

            //classes
            services.AddTransient<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
