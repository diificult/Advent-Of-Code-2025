using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public  class Day3
    {
        public static void Run(int part)
        {
            var input = InputReader.ReadInputLines(3);

            if (part == 1)
            {
                Part1(input);

            } 
            if (part == 2)
            {
                Part2(input);
            }

        }

        private static void Part1(string[] input)
        {

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
        private static void Part2(string[] input)
        {
            Int128 answer = 0;

            foreach (string line in input)
            {
                string updateableLine = line;
                while (updateableLine.Length > 12)
                {
                    int firstLowestCharIndex = updateableLine.IndexOf(updateableLine.Min());
                    updateableLine = updateableLine.Remove(firstLowestCharIndex, 1);
                }

                    Console.WriteLine(updateableLine);
                answer += Int128.Parse(updateableLine);
                


            }
            Console.WriteLine("Answer: " + answer);

        }


    }
}
