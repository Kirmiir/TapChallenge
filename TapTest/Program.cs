using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using TapTest.Interfaces;
using TapTest.Modules;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TapTest
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration() 
                .Enrich.FromLogContext() 
                .WriteTo.File("log.txt") 
                .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddRepositories()
                .AddLogicServices()
                .AddSingleton<IApplicationService, App>()
                .AddLogging(b => b.AddSerilog())
                .AddTransient<ILogger>(s => s.GetService<ILogger<Program>>())
                .BuildServiceProvider();

            serviceProvider.GetService<LoggerFactory>()?.AddSerilog();

            var bar = serviceProvider.GetService<IApplicationService>();
            bar?.Run(args);
        }
    }
}