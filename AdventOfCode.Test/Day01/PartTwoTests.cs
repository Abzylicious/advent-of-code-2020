using AdventOfCode.Day01;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01
{
    [TestFixture]
    public class PartTwoTests
    {
        /// <summary>
        /// Using the above example again, the three entries that sum to 2020 are 979, 366, and 675. Multiplying them together produces the answer, 241861950.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var input = new[] { 1721, 979, 366, 299, 675, 1456 };
            var actual = ExpenseReportAnalyzer.MultiplyThreeTargetValues(input);
            actual.Should().Be(241861950);
        }
    }
}
