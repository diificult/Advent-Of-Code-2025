using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public  class Day3
    {
        public static void Run()
        {
            var input = InputReader.ReadInputLines(3);

            int answer = 0;

            foreach (var line in input)
            {

                char max = line[..^1].Max();

                int maxIndex = line.IndexOf(max);

                char maxAftermax = line.Substring(maxIndex + 1).Max();

                int biggestValue = (int.Parse(max.ToString()) * 10) + int.Parse(maxAftermax.ToString());

                answer += biggestValue;

            }
                Console.WriteLine("Answer: " + answer);
            
        }
    }
}
