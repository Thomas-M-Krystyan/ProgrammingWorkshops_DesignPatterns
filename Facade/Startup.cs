using Facade.Controllers;
using Facade.Facade;
using Facade.Services.Displays;
using Facade.Services.Displays.Interfaces;
using Facade.Services.Mathematics;
using Facade.Services.Mathematics.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Facade
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

            // Facade
            services.AddSingleton<ICalculationFacade, RichCalculationFacade>();

            // Mathematics
            services.AddSingleton<ICalculate<AddingService>, AddingService>();
            services.AddSingleton<ICalculate<MultiplyingService>, MultiplyingService>();
            
            // Displays
            services.AddSingleton<IDisplay, RichTextService>();
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
                endpoints.MapControllerRoute(
                    name: @"default",
                    pattern: $@"{{controller={GetControllerName<HomeController>()}}}/{{action={nameof(HomeController.Index)}}}/{{viewModel?}}");
                endpoints.MapControllerRoute(
                    name: @"partial",
                    pattern: $@"{{controller={GetControllerName<HomeController>()}}}/{{action={nameof(HomeController.Recalculate)}}}/{{dto}}");
            });
        }

        /// <summary>
        /// Gets the MVC Controller name by returning only the name without "Controller" word.
        /// </summary>
        /// <typeparam name="T">The type of MVC <see cref="Controller"/>.</typeparam>
        /// <returns>Simplified MVC Controller name.</returns>
        public static string GetControllerName<T>() where T : Controller
        {
            return typeof(T).Name.Replace(nameof(Controller), String.Empty);
        }
    }
}
