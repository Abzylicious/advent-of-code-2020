namespace AdventOfCode.Services
{
    public interface IInputFileService<T>
    {
        T GetFileContents(string filePath, string delimiter);
    }
}
