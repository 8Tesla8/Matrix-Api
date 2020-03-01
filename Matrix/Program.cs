using MatrixApi.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MatrixApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Injection.BeginLifetimeScope();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
