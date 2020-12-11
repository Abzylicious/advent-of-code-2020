using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Services
{
    public interface ISolveService
    {
        string GetTitle(int day);
        IEnumerable<string> GetSolutions(int day);
    }

    public class SolveService : ISolveService
    {
        private readonly IServiceProvider _services;

        public SolveService(IServiceProvider services) => _services = services;

        public string GetTitle(int day)
        {
            var solver = GetSolver(day);
            return solver is null ? string.Empty : solver.Title;
        }

        public IEnumerable<string> GetSolutions(int day)
        {
            var solver = GetSolver(day);
            return solver is null ? Enumerable.Empty<string>() : solver.Solve();
        }

        private ISolver GetSolver(int day) => _services.GetServices<ISolver>().FirstOrDefault(solver => solver.Day == day);
    }
}
