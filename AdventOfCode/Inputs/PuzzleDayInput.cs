using System;

namespace AdventOfCode.Inputs
{
    public class PuzzleDayInput : IPuzzleDayInput
    {
        private readonly IInput<int> _consoleNumberInput;

        public PuzzleDayInput(IConsoleNumberInput consoleNumberInput) => _consoleNumberInput = consoleNumberInput;

        public int GetInput()
        {
            Console.Write("Enter a day to view its solution: ");
            var day = _consoleNumberInput.GetInput();

            if (!IsValidPuzzleDay(day))
            {
                Console.WriteLine("Advent of Code takes place between the 1. and 25. of December. Please enter a valid value.");
                return GetInput();
            }

            return day;
        }

        private static bool IsValidPuzzleDay(int day) => day > 0 && day <= 25;
    }
}
