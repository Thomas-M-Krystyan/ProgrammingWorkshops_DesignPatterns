using Command_Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Command
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC Controllers
            services.AddControllersWithViews();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            // Detailed exceptions in Development mode
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            // Use HTTPS protocol
            application.UseHttpsRedirection();

            // Include static files such as HTML styles, images, etc.
            application.UseStaticFiles();

            // Endpoints
            application.UseRouting();
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: @"default", pattern: $@"{{controller=Home}}/{{action={nameof(HomeController.Index)}}}");
            });
        }
    }
}
