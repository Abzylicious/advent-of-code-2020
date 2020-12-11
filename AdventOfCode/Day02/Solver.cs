using AdventOfCode.Inputs;
using AdventOfCode.Services;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public class Solver : ISolver
    {
        private readonly IFilePathInput _filePathInput;
        private readonly ITextInputFileService _textInputFileService;
        private IEnumerable<string> _input;

        public Solver(IFilePathInput filePathInput, ITextInputFileService textInputFileService) =>
            (_filePathInput, _textInputFileService) = (filePathInput, textInputFileService);

        public int Day => 2;
        public string Title => "--- Day 2: Password Philosophy ---";

        public void Setup()
        {
            var inputFile = _filePathInput.GetInput();
            _input = _textInputFileService.GetFileContents(inputFile, "\n");
        }

        public IEnumerable<string> Solve()
        {
            Setup();
            return new List<int>
            {
                PasswordDatabase.GetValidPasswordCount(_input, new CharacterOccurrencePasswordPolicyValidator()),
                PasswordDatabase.GetValidPasswordCount(_input, new CharacterIndexPasswordPolicyValidator())
            }.ConvertAll(Convert.ToString);
        }
    }
}
