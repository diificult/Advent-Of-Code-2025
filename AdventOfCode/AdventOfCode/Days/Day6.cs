using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day6
    {

        public static void Run(int part)
        {
            {
                if (part == 1)
                {
                    Part1(InputReader.ReadInputLines(6));
                }
                else if (part == 2)
                {
                    Part2(InputReader.ReadInputLines(6));
                }
            }

        }
        public static void Part1(string[] input)
        {

            var numbers = new List<List<long>>();

            foreach (var line in input.SkipLast(1))
            {
                var lineSplit = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(z => long.Parse(z)).ToList();
                numbers.Add(lineSplit);
            }

            var summing = input[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => (c, c == "+" ? 0l : 1l)).ToList();

            foreach (var line in numbers)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    summing[i] = (summing[i].c ,summing[i].c == "+" ? summing[i].Item2 + line[i] : summing[i].Item2 * line[i]);
                }
            }

            long ans = 0;
            foreach (var sum in summing)
            {
                ans += sum.Item2;
            }
            Console.WriteLine("Answer: " + ans);


        }

        public static void Part2(string[] input)
        {

            var numbers = new List<List<string>>();
           // var symbols = input[^1].Select(c => c.ToString());
            var summing = input[^1].Select(c => c.ToString()).Select(c => (c, c == "*" ? 1l : 0l)).ToList();
            

            foreach (var line in input.SkipLast(1))
            {
                var lineSplit = line.Select(z => z.ToString()).ToList();
                numbers.Add(lineSplit);
            }
            
            while (summing.Count < numbers[0].Count) summing.Add((" ", 0));


            for (int i = numbers[0].Count - 1; i >= 0; i--)
            {
                var number = "";
                foreach (var line in numbers)
                {
                    number += line[i];
                }

                int z = 0;
                while (string.IsNullOrWhiteSpace(summing[i - z].c))
                {
                    z++;
                }

                if (!string.IsNullOrWhiteSpace(number)) {
                    summing[i - z] = (summing[i - z].c, summing[i - z].c == "+" ? summing[i - z].Item2 + long.Parse(number) : summing[i - z].Item2 * long.Parse(number));
                    Console.WriteLine($"{number} means {summing[i - z].Item2} is now the value for {i - z} as it is a {summing[i - z].c}");
                        
                        };
            }

            long ans = 0;
            foreach (var sum in summing)
            {
                ans += sum.Item2;
            }
            Console.WriteLine("Answer: " + ans);

        }
    }
}
