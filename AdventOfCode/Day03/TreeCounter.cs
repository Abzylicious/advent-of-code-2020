using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class TreeCounter
    {
        private readonly MapTraverser _mapTraverser;

        public TreeCounter(IEnumerable<string> map) => _mapTraverser = new MapTraverser(map);

        public int GetTreeCountForDefinedSlope() => GetTreeCountForSlope(3, 1);

        public int MultiplyTreeCountForAllSlopes()
        {
            var treeCounts = new List<int>
            {
                GetTreeCountForSlope(1, 1),
                GetTreeCountForDefinedSlope(),
                GetTreeCountForSlope(5, 1),
                GetTreeCountForSlope(7, 1),
                GetTreeCountForSlope(1, 2)
            };

            return treeCounts.Aggregate((first, second) => first * second);
        }

        private int GetTreeCountForSlope(int slopeX, int slopeY) => _mapTraverser.GetTreeCountAfterTraverse(slopeX, slopeY);
    }
}
