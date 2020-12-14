using AdventOfCode.Day03;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode.Test.Day03
{
    [TestFixture]
    public class PartTwoTests
    {
        [Test]
        public void ExampleOne()
        {
            var map = new List<string>
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };

            var treeCounter = new TreeCounter(map);
            var actual = treeCounter.MultiplyTreeCountForAllSlopes();
            actual.Should().Be(336);
        }
    }
}
