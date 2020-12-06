using AdventOfCode.Inputs;
using AdventOfCode.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

[assembly: CLSCompliant(true)]
namespace AdventOfCode
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var host = CreateHost(args);
            var adventOfCode = ActivatorUtilities.CreateInstance<AdventOfCode>(host.Services);
            adventOfCode.Run();
        }

        private static IHost CreateHost(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices)
            .ConfigureLogging(ConfigureLogging)
            .Build();

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPuzzleDayInput, PuzzleDayInput>();
            services.AddTransient<IConsoleNumberInput, ConsoleNumberInput>();
            services.AddTransient<ISolveService, SolveService>();
            RegisterSolvers(services);
        }

        private static void RegisterSolvers(IServiceCollection services)
        {
            var solvers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ISolver).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);

            foreach (var solver in solvers)
            {
                services.AddTransient(typeof(ISolver), solver.GetType());
            }
        }

        private static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddConsole();
        }
    }
}
