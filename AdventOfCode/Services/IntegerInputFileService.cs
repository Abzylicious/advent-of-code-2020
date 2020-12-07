using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public interface IIntegerInputFileService : IInputFileService<IEnumerable<int>> { }

    public class IntegerInputFileService : IIntegerInputFileService
    {
        public IEnumerable<int> GetFileContents(string filePath, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return Enumerable.Empty<int>();

            try
            {
                var input = !string.IsNullOrEmpty(delimiter)
                    ? File.ReadAllText(filePath).Split(delimiter).Where(entry => !string.IsNullOrWhiteSpace(entry))
                    : new[] { File.ReadAllText(filePath) };

                return input.ToList().ConvertAll(Convert.ToInt32);
            }
            catch
            {
                Console.WriteLine("The input file is not formatted as expected.");
                return Enumerable.Empty<int>();
            }
        }
    }
}
