using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {
        private static Dictionary<Town, List<Town>> graph = new Dictionary<Town, List<Town>>();
        private static HashSet<Town> visited = new HashSet<Town>();

        static void Main()
        {
            //Console.SetIn(new StreamReader("../../input.txt"));

            //must implement deikstra algorithm

            List<Town> towns = new List<Town>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] townData = Console.ReadLine().Trim().Split(' ');
                var town = new Town(townData[1], long.Parse(townData[0]));
                towns.Add(town);
            }

            Console.WriteLine(1);
        }

    }

    public class Town
    {
        public Town(string name, long numberOfCitizens)
        {
            this.TownName = name;
            this.Citizens = numberOfCitizens;
        }
        public string TownName { get; set; }

        public long Citizens { get; set; }
    }
}
