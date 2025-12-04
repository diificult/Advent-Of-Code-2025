using AdventOfCode.Common;
using System.Diagnostics;
using System.Dynamic;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Days
{
    public class Day4
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(4));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(4));
            }
        }

        public static void Part1(string[] input)
        {
            var watch = Stopwatch.StartNew();
            char[][] arr = new char[input.Length][];

            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = input[i].ToArray();
            }
            int ans = 0;

            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input[0].Length; y++)
                {
                  //  Console.Write(arr[x][y]);
                    if (arr[x][y] != '@') continue; 
                    

                    int count = 0;

                    if (Get(arr, x-1, y-1) == '@') count++;
                    if (Get(arr, x, y-1) == '@') count++;
                    if (Get(arr, x+1, y-1) == '@') count++;
                    if (Get(arr, x-1, y) == '@') count++;
                    if (Get(arr, x+1, y) == '@') count++;
                    if (Get(arr, x-1, y+1) == '@') count++;
                    if (Get(arr, x, y+1) == '@') count++;
                    if (Get(arr, x+1, y+1) == '@') count++;
                    if (count <= 3) ans++;
                }
                //Console.WriteLine();
            }

            watch.Stop();
            Console.WriteLine("Answer " + ans + " time taken " + watch.Elapsed);



        }

        private static char? Get(char[][] arr, int x, int y)
        {
            if (x < 0 || x >= arr.Length) return null;
            if (y < 0 || y >= arr[x].Length) return null;
            return arr[x][y];
        }

        public static void Part2(string[] input)
        {

            var watch = Stopwatch.StartNew();
            char[][] arr = new char[input.Length][];

            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = input[i].ToArray();
            }
            int ans = 0;

            char[][] newArr;
            int count;
            while ((count = RemoveRolls(arr, out newArr)) != 0)
            {
                ans += count;
                Console.WriteLine(count);
                arr = newArr;
            }




            watch.Stop();
            Console.WriteLine("Answer " + ans + " time taken " + watch.Elapsed);



        }


        public static int RemoveRolls(char[][] arr, out char[][] next)
        {

            int rows = arr.Length;
            int cols = arr[0].Length;
            next = arr.Select(row => row.ToArray()).ToArray();
            int result = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    //  Console.Write(arr[x][y]);
                    if (arr[x][y] != '@') continue;


                    int count = 0;

                    if (Get(arr, x - 1, y - 1) == '@') count++;
                    if (Get(arr, x, y - 1) == '@') count++;
                    if (Get(arr, x + 1, y - 1) == '@') count++;
                    if (Get(arr, x - 1, y) == '@') count++;
                    if (Get(arr, x + 1, y) == '@') count++;
                    if (Get(arr, x - 1, y + 1) == '@') count++;
                    if (Get(arr, x, y + 1) == '@') count++;
                    if (Get(arr, x + 1, y + 1) == '@') count++;
                    if (count <= 3)
                    {
                        next[x][y] = '.';
                        result++;
                    
                    }
                }

                
                //Console.WriteLine();
            }
            return result;

        }
    }
}
