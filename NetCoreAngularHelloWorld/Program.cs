using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NetCoreAngularHelloWorld
{
    /// <summary>
    /// Entry point for the app.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // .Net core no longer uses IIS.
            // It can be hooked into IIS or run independently
            // What the below is doing is configuring Kestrel aka HTTP server for .net core to receive requests
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
