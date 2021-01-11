using AutoMapper;
using HumbleBob.Bll.Mapper;
using HumbleBob.Web.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace HumbleBob.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfileBll), typeof(MapperProfileWeb));
            services.AddControllersWithViews();

            return services;
        }
    }
}
