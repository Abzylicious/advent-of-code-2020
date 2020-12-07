using AdventOfCode.Day01;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Test.Day01
{
    [TestFixture]
    public class PartOneTests
    {
        /// <summary>
        /// In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.
        /// </summary>
        [Test]
        public void ExampleOne()
        {
            var input = new[] { 1721, 979, 366, 299, 675, 1456 };
            var actual = ExpenseReportAnalyzer.MultiplyTwoTargetValues(input);
            actual.Should().Be(514579);
        }
    }
}
