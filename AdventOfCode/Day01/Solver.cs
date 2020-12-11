using AdventOfCode.Inputs;
using AdventOfCode.Services;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day01
{
    public class Solver : ISolver
    {
        private readonly IFilePathInput _filePathInput;
        private readonly IIntegerInputFileService _integerInputFileService;
        private IEnumerable<int> _input;

        public Solver(IFilePathInput filePathInput, IIntegerInputFileService integerInputFileService) =>
            (_filePathInput, _integerInputFileService) = (filePathInput, integerInputFileService);

        public int Day => 1;
        public string Title => "--- Day 1: Report Repair ---";

        public void Setup()
        {
            var inputFile = _filePathInput.GetInput();
            _input = _integerInputFileService.GetFileContents(inputFile, "\n");
        }

        public IEnumerable<string> Solve()
        {
            Setup();
            return new List<long>
            {
                ExpenseReportAnalyzer.MultiplyTwoTargetValues(_input),
                ExpenseReportAnalyzer.MultiplyThreeTargetValues(_input)
            }.ConvertAll(Convert.ToString);
        }
    }
}
