using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Day03
{
    public class MapTraverser
    {
        private readonly char[][] _map;
        private readonly int _maxX;
        private readonly int _maxY;
        private readonly Vector2 _startingPosition = new Vector2(0, 0);
        private const char _tree = '#';

        public MapTraverser(IEnumerable<string> map)
        {
            _map = map.ToArray().Select(row => row.ToArray()).ToArray();
            _maxX = _map[0].Length;
            _maxY = _map.Length;
        }

        public int GetTreeCountAfterTraverse(int stepRight, int stepDown)
        {
            var currentPosition = _startingPosition;
            var step = new Vector2(stepRight, stepDown);
            var treeCount = 0;

            while (currentPosition.Y < _maxY)
            {
                currentPosition = StepForward(currentPosition, step);

                if (GetLocation(currentPosition) == _tree)
                    treeCount++;
            }

            return treeCount;
        }

        private char GetLocation(Vector2 position) =>
            position.X < _maxX && position.Y < _maxY ? _map[(int)position.Y][(int)position.X] : ' ';

        private Vector2 StepForward(Vector2 position, Vector2 step)
        {
            position += step;

            if (position.X >= _maxX)
                position.X -= _maxX;

            return position;
        }
    }
}
