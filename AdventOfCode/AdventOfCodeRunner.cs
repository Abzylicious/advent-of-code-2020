﻿using AdventOfCode.Inputs;
using AdventOfCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class AdventOfCodeRunner
    {
        private readonly ISolveService _solveService;
        private readonly IPuzzleDayInput _puzzleDayInput;

        public AdventOfCodeRunner(ISolveService solveService, IPuzzleDayInput puzzleDayInput) =>
            (_solveService, _puzzleDayInput) = (solveService, puzzleDayInput);

        public void Run()
        {
            Console.WriteLine("Advent of Code 2020\n");

            do
            {
                var day = _puzzleDayInput.GetInput();

                var title = _solveService.GetTitle(day);
                if (!string.IsNullOrEmpty(title))
                    Console.WriteLine($"\n{title}");

                var solutions = _solveService.GetSolutions(day);
                if (solutions == Enumerable.Empty<string>())
                    Console.WriteLine("There's no solution for this day yet.");

                DisplaySolutions(solutions);
                Console.WriteLine("\nDo you want to check upon other days? Press any key to continue, press 'ESCAPE' or 'Ctrl + C' to exit.\n");

            } while (Continue());
        }

        private static void DisplaySolutions(IEnumerable<string> solutions)
        {
            foreach (var solution in solutions)
            {
                Console.WriteLine(solution);
            }
        }

        private static bool Continue() => Console.ReadKey(true).Key != ConsoleKey.Escape;
    }
}
