namespace GrapfhAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Using adjancency list and recursively DFS
    /// </summary>
    public class Salaries
    {
        private static readonly IDictionary<int, List<int>> AdjacencyList = new Dictionary<int, List<int>>();
        private static long[] employees;

        public static void Main()
        {
            Console.SetIn(new StreamReader("../../input.txt"));

            ParseInput();

            var totalSalary = CalculateTotalSalary();

            Console.WriteLine("Total salary: " + totalSalary);
        }

        public static void ParseInput()
        {
            var n = int.Parse(Console.ReadLine());
            employees = new long[n];

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                AdjacencyList[i] = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (inputLine[j] == 'Y')
                    {
                        AdjacencyList[i].Add(j);
                    }
                }

                if (AdjacencyList[i].Count == 0)
                {
                    employees[i] = 1;
                }
            }
        }

        public static long CalculateTotalSalary()
        {
            long totalSalary = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                totalSalary += Calculate(i);
            }

            return totalSalary;
        }

        public static long Calculate(int employeeId)
        {
            if (employees[employeeId] != 0)
            {
                return employees[employeeId];
            }

            foreach (var employee in AdjacencyList[employeeId])
            {
                employees[employeeId] += Calculate(employee);
            }

            return employees[employeeId];
        }
    }
}