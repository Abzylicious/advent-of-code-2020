using AdventOfCode.Inputs;
using AdventOfCode.Services;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day03
{
    public class Solver : ISolver
    {
        private readonly IFilePathInput _filePathInput;
        private readonly ITextInputFileService _textInputFileService;
        private IEnumerable<string> _input;

        public Solver(IFilePathInput filePathInput, ITextInputFileService textInputFileService) =>
            (_filePathInput, _textInputFileService) = (filePathInput, textInputFileService);

        public int Day => 3;
        public string Title => "--- Day 3: Toboggan Trajectory ---";

        public void Setup()
        {
            var inputFile = _filePathInput.GetInput();
            _input = _textInputFileService.GetFileContents(inputFile, "\n");
        }

        public IEnumerable<string> Solve()
        {
            Setup();
            var treeCounter = new TreeCounter(_input);

            return new List<int>
            {
                treeCounter.GetTreeCountForDefinedSlope(),
                treeCounter.MultiplyTreeCountForAllSlopes()
            }.ConvertAll(Convert.ToString);
        }
    }
}
