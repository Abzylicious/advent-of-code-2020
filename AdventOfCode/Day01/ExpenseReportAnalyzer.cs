using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day01
{
    public static class ExpenseReportAnalyzer
    {
        public static long MultiplyTwoTargetValues(IEnumerable<int> report)
        {
            var result = from first in report
                         let second = 2020 - first
                         where report.Contains(second)
                         select first * second;

            return result.FirstOrDefault();
        }

        public static long MultiplyThreeTargetValues(IEnumerable<int> report)
        {
            var result = from first in report
                         from second in report
                         let third = 2020 - first - second
                         where report.Contains(third)
                         select first * second * third;

            return result.FirstOrDefault();
        }
    }
}
