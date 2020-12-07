using System;

namespace AdventOfCode.Inputs
{
    public interface IConsoleNumberInput : IInput<int> { }

    public class ConsoleNumberInput : IConsoleNumberInput
    {
        public int GetInput()
        {
            int number;
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("The entered value is not a number, enter a number: ");
            }

            return number;
        }
    }
}
