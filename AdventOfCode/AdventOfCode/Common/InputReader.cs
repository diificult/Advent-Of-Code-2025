namespace AdventOfCode.Common
{

    public static class InputReader
    {
        public static string[] ReadInputLines(int day)
        {
            string filePath = $"Inputs/Day{day}.txt";
            return System.IO.File.ReadAllLines(filePath);
        }
    }
}