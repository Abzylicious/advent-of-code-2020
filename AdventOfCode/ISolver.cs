using System.Collections.Generic;

namespace AdventOfCode
{
    public interface ISolver
    {
        public int Day { get; }
        public string Title { get; }
        public void Setup();
        public IEnumerable<string> Solve();
    }
}
