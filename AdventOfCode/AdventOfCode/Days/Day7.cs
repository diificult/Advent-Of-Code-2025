using AdventOfCode.Common;
namespace AdventOfCode.Days
{
    public class Day7
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(7));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(7));
            }
        }

        public static void Part1(string[] input)
        {
            char[][] board = new char[input.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = input[i].ToCharArray();
            }

            List<(int x, int y)> beams = new List<(int x, int y)>();

            beams.Add((board[0].IndexOf("S"), 0));

            int ans = 0;
            while (beams[0].y < board.Length - 1)
            {
                var newBeams = new List<(int x, int y)>();
                foreach (var beam in beams)
                {
                    //Spliter
                    if (board[beam.y + 1][beam.x] == '^')
                    {
                        newBeams.Add((beam.x - 1, beam.y + 1));
                        newBeams.Add((beam.x + 1, beam.y + 1));
                        ans++;
                    } else
                    {
                        newBeams.Add((beam.x, beam.y +1));
                    }
                }
                beams = newBeams.Distinct().ToList();
            }

            Console.WriteLine("Answer: " + ans);

        }

        public static void Part2(string[] input)
        {
        }
    }
}

