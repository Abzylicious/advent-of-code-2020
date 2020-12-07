using System;
using System.IO;

namespace AdventOfCode.Inputs
{
    public interface IFilePathInput : IInput<string> { }

    public class FilePathInput : IFilePathInput
    {
        public string GetInput()
        {
            Console.Write("Enter path to input.txt file: ");
            var filePath = SanatizeFilePath(Console.ReadLine());

            if (!File.Exists(filePath))
            {
                Console.WriteLine("input.txt file not found. Please enter the path to your input.txt file.");
                return GetInput();
            }

            return filePath;
        }

        private static string SanatizeFilePath(string filePath)
        {
            if (filePath.StartsWith("\"", StringComparison.Ordinal))
                filePath = filePath[1..];

            if (filePath.EndsWith("\"", StringComparison.Ordinal))
                filePath = filePath.Remove(filePath.Length - 1);

            return filePath;
        }
    }
}
