namespace GrapfhAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Using Dijsktra Algorithm without priority queue
    /// </summary>
    public class FriendsOfPesho
    {
        private static IList<Node>[] graph;
        private static ISet<int> hospitalIds;

        public static void Main()
        {
            Console.SetIn(new StreamReader("../../input.txt"));

            ParseInput();

            var minDistance = FindMinSum(hospitalIds);

            Console.WriteLine("Minimal distance: " + minDistance);
        }

        public static void ParseInput()
        {
            var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            graph = Enumerable.Range(0, parameters[0]).Select(i => new List<Node>()).ToArray();

            hospitalIds = new HashSet<int>(Console.ReadLine().Split(' ').Select(a => int.Parse(a) - 1));

            for (int i = 0; i < parameters[1]; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int parent = input[0] - 1, child = input[1] - 1;

                graph[parent].Add(new Node(child, input[2]));
                graph[child].Add(new Node(parent, input[2]));
            }
        }

        public static int FindMinSum(ISet<int> hospitalIds)
        {
            var minDistance = int.MaxValue;

            foreach (var item in hospitalIds)
            {
                minDistance = Math.Min(
                    minDistance, 
                    FindMinimalDistance(item).Where((a, b) => !hospitalIds.Contains(b)).Sum());
            }

            return minDistance;
        }

        public static IEnumerable<int> FindMinimalDistance(int source)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(new Node(source, 0));

            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[source] = 0;

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                foreach (var neighbour in graph[currentNode.Id])
                {
                    int currentDistance = distances[currentNode.Id] + neighbour.Distance;

                    if (currentDistance < distances[neighbour.Id])
                    {
                        distances[neighbour.Id] = currentDistance;
                        queue.Enqueue(new Node(neighbour.Id, currentDistance));
                    }
                }
            }

            return distances;
        }

        public struct Node
        {
            public Node(int id, int distance)
                : this()
            {
                this.Id = id;
                this.Distance = distance;
            }

            public int Id { get; set; }

            public int Distance { get; set; }
        }
    }
}