using AdventOfCode.Common;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;

namespace AdventOfCode.Days
{
    public class JunctionBox
    {

        public Vector3 coords;

        public JunctionBox() { }

    }


    public class Day8
    {

        public static void Run(int part)
        {
            if (part == 1)
            {
                Part1(InputReader.ReadInputLines(8));
            }
            else if (part == 2)
            {
                Part2(InputReader.ReadInputLines(8));
            }
        }

        public static void Part1(string[] input)
        {
            Console.Write("Number of pairs: ");
            var noOfPairs = int.Parse(Console.ReadLine());

            var circuits = new List<List<JunctionBox>>();

            foreach (var circuit in input)
            {
                var c = circuit.Split(',').Select(s => int.Parse(s)).ToList();
                var coords = new JunctionBox
                {
                    coords = new Vector3(c[0], c[1], c[2])

                };

                circuits.Add(new List<JunctionBox>() { coords });
            }

            var sortedDistances = new PriorityQueue<(float d, JunctionBox a, JunctionBox b), float>();
            for (int i = 0; i < circuits.Count; i++)
            {
                for (int j = i + 1; j < circuits.Count; j++)
                {

                    var c = circuits[i];
                    var y = circuits[j];

                    var distance = Vector3.Distance(c[0].coords, y[0].coords);
                    sortedDistances.Enqueue((distance, c[0], y[0]), -distance);
                    if (sortedDistances.Count > noOfPairs)
                    {
                       sortedDistances.Dequeue();

                    }

                }
            }

            var edges = sortedDistances.UnorderedItems
               .Select(x => x.Element)
               .OrderBy(x => x.d)
               .ToList();

            int completedCount = 0;

            //Defo could come back and learn how to make this section efficent  
            foreach (var distance in edges)
            {
                
                var circuit = circuits.First(c => c.Contains(distance.Item2));
                var otherCircuit = circuits.First(c => c.Contains(distance.Item3));
                if (circuit == otherCircuit) { 
                    continue; 
                }
                
                var joinCircuit = circuit.Concat(otherCircuit).ToList();


                circuits.Add(joinCircuit);
                circuits.Remove(circuit);
                circuits.Remove(otherCircuit);
                
            }

            var sizeOrder = circuits.OrderBy(c => c.Count).ToList();
            var ans = sizeOrder[^1].Count * sizeOrder[^2].Count * sizeOrder[^3].Count;
            
            Console.WriteLine("Answer: " + ans);
        }

        public static void Part2(string[] input)
        {
            var circuits = new List<List<JunctionBox>>();

            foreach (var circuit in input)
            {
                var c = circuit.Split(',').Select(s => int.Parse(s)).ToList();
                var coords = new JunctionBox
                {
                    coords = new Vector3(c[0], c[1], c[2])

                };

                circuits.Add(new List<JunctionBox>() { coords });
            }

            var sortedDistances = new PriorityQueue<(float d, JunctionBox a, JunctionBox b), float>();
            for (int i = 0; i < circuits.Count; i++)
            {
                for (int j = i + 1; j < circuits.Count; j++)
                {

                    var c = circuits[i];
                    var y = circuits[j];

                    var distance = Vector3.Distance(c[0].coords, y[0].coords);
                    sortedDistances.Enqueue((distance, c[0], y[0]), -distance);

                }
            }

            var edges = sortedDistances.UnorderedItems
               .Select(x => x.Element)
               .OrderBy(x => x.d)
               .ToList();

            int completedCount = 0;

            //Defo could come back and learn how to make this section efficent  
            foreach (var distance in edges)
            {

                var circuit = circuits.First(c => c.Contains(distance.Item2));
                var otherCircuit = circuits.First(c => c.Contains(distance.Item3));
                if (circuit == otherCircuit)
                {
                    continue;
                }

                var joinCircuit = circuit.Concat(otherCircuit).ToList();


                circuits.Add(joinCircuit);
                circuits.Remove(circuit);
                circuits.Remove(otherCircuit);
                if (circuits.Count == 1)
                {
                    
                    var ans = distance.a.coords.X * distance.b.coords.X;
                    Console.WriteLine("Answer:  " + ans);
                }

            }
        }
    }
}
