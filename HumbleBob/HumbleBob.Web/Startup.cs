using HumbleBob.Bll.Extensions;
using HumbleBob.Dal.Extensions;
using HumbleBob.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HumbleBob.Web
{
    public class Startup
    {
        private const string DbConnectionStringName = "HumbleBobDb";

        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDal(Configuration, DbConnectionStringName);
            services.AddBll();
            services.AddWeb();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Items}/{action=GetReadOnlyItems}/");
            });
        }
    }
}
