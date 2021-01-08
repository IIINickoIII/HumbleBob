using HumbleBob.Bll.Interfaces;
using HumbleBob.Bll.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HumbleBob.Bll.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();

            return services;
        }
    }
}
