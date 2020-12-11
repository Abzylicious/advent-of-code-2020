using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Services
{
    public interface ITextInputFileService : IInputFileService<IEnumerable<string>> { }

    public class TextInputFileService : ITextInputFileService
    {
        public IEnumerable<string> GetFileContents(string filePath, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return Enumerable.Empty<string>();

            try
            {
                return !string.IsNullOrEmpty(delimiter)
                    ? File.ReadAllText(filePath).Split(delimiter).Where(entry => !string.IsNullOrWhiteSpace(entry))
                    : new[] { File.ReadAllText(filePath) };
            }
            catch
            {
                Console.WriteLine("The input file is not formatted as expected.");
                return Enumerable.Empty<string>();
            }
        }
    }
}
