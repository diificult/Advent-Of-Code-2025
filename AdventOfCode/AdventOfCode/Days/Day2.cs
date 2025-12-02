using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;

namespace AdventOfCode.Days
{
    public class Day2
    {

        public static void Run()
        {
            var input = InputReader.ReadInputLines(2);
            var ranges = input[0].Split(',');
            var total = 0l;

            foreach (string range in ranges)
            {
                var rangeSplit = range.Split('-');
                var rangeMin =  Int64.Parse(rangeSplit[0]);
                var rangeMax = Int64.Parse(rangeSplit[1]);

                for (Int64 i = rangeMin; i <= rangeMax; i++)
                {
                    string checkString = i.ToString();

                    int checkLength = checkString.Length;
                    for (int j = 1; j <= checkLength; j++)
                    {

                        if (checkLength % j != 0) continue;

                        List<string> checks = new List<string>();
                        for (int x = 0; x <= checkLength - j; x += j)
                        {
                            checks.Add(checkString.Substring(x, j));
                        }




                        if (checks.Distinct().Count() == 1 && checks.Count != 1) 
                        {
                            Console.WriteLine("Found invalid ID " + i +  " with j = " + j);
                            total += i;
                            break;
                        }



                        //if (checkString.Substring(0, checkLength / j) == checkString.Substring(checkLength / j)) total += i;

                    }
                        
                    

                }

            }

            Console.WriteLine("total: " + total);


        }

    }
}
