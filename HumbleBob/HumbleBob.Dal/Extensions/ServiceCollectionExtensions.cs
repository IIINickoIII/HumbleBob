using HumbleBob.Dal.Contexts;
using HumbleBob.Dal.Interfaces;
using HumbleBob.Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumbleBob.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDal(
            this IServiceCollection services,
            IConfiguration configuration,
            string dbConnectionStringName)
        {
            services.AddDbContext<HumbleBobContext>(config => config.UseSqlServer(configuration.GetConnectionString(dbConnectionStringName)));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
