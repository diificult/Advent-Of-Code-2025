namespace AdventOfCode.Common
{

    public static class InputReader
    {
        public static string[] ReadInputLines(int day)
        {
            try
            {
                string filePath = $"Inputs/Day{day}.txt";
                return System.IO.File.ReadAllLines(filePath);
            } catch(Exception e)
            {
                Console.WriteLine("Error with your input file");
                return null;
            }

        }
    }
}