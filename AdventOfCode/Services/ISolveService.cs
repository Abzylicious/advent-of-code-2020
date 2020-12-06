using System.Collections.Generic;

namespace AdventOfCode.Services
{
    public interface ISolveService
    {
        IEnumerable<string> GetSolutions(int day);
    }
}
