using Facade.Controllers;
using Facade.Services.Displays;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Facade
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICalculate,AddingService>();
            services.AddSingleton<ICalculate,MultiplyingService>();
            services.AddSingleton<IDisplay, RichTextService>();
            services.AddControllersWithViews();
            
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: @"default",
                    pattern: @"{controller=Home}/{action=" + $"{nameof(HomeController.Homepage)}" + "}/{id?}");
                //@"{controller=Home}/{action=" + $"{nameof(HomeController.Homepage)}" + "}/{id?}"
            });
        }
    }
}
