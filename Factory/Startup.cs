using Factory.Exercise.Abstractions;
using Factory.Exercise.Factories;
using Factory.Exercise.Interfaces;
using Factory.Exercise.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProduct, ProductBase>();

            services.AddSingleton<IFactory, ProductsFactory>();
            services.AddSingleton<ICollectingService, Wishlist>();
            services.AddSingleton<ICollectingService, ShoppingCart>();
        }
    }
}
