using Builder.Exercise.Builder.Handler;
using Builder.Exercise.Factory.Handler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Builder
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
        public static void ConfigureServices(IServiceCollection services)
        {
            // Builder
            services.AddSingleton<BuilderDirector>();

            // Factory
            services.AddSingleton<FactoryManager>();
        }
    }
}
