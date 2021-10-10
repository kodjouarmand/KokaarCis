using Microsoft.Extensions.DependencyInjection;
using KokaarCis.DataAccess.Repositories;
using KokaarCis.DataAccess.Repositories.Contracts;

namespace KokaarCis.Infrastructure
{
    public static class DbServiceExtention
    {        
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
