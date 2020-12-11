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
            var adventOfCodeRunner = ActivatorUtilities.CreateInstance<AdventOfCodeRunner>(host.Services);
            adventOfCodeRunner.Run();
        }

        private static IHost CreateHost(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices)
            .ConfigureLogging(ConfigureLogging)
            .Build();

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPuzzleDayInput, PuzzleDayInput>();
            services.AddTransient<IConsoleNumberInput, ConsoleNumberInput>();
            services.AddTransient<IFilePathInput, FilePathInput>();
            services.AddTransient<IIntegerInputFileService, IntegerInputFileService>();
            services.AddTransient<ITextInputFileService, TextInputFileService>();
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
                services.AddTransient(typeof(ISolver), solver);
            }
        }

        private static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddConsole();
        }
    }
}
