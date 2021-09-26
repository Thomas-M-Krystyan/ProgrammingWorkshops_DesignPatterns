using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace Singleton
{
    public static class Program
    {
        public static void Main()
        {
           // CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //         .ConfigureLogging((context, logging) =>
        //         {
        //             logging.ClearProviders();
        //             logging.AddConsole();
        //         })
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
        //}
    }
}
