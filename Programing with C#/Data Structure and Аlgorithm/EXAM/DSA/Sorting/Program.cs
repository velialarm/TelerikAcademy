using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        private static int count = 0;

        static void Main()
        {
            //Console.SetIn(new StreamReader("../../input.txt"));

            int n = int.Parse(Console.ReadLine());

            string[] strOfNum = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int>();
            for (int i = 0; i < strOfNum.Length; i++)
            {
                numbers.Add(int.Parse(strOfNum[i]));
            }

            //posledovatelni elementa K
            int k = int.Parse(Console.ReadLine());

            Sort(numbers);
            Console.WriteLine(count == 0 ? 0 : count-1);
        }

        public static void Sort(IList<int> collection)
        {
            int swapIndex = 0;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[swapIndex].CompareTo(collection[j]) > 0)
                    {
                        count++;
                        swapIndex = j;
                    }
                }

                Swap(collection, i, swapIndex);
            }
        }

        private static void Swap(IList<int> collection, int i, int swapIndex)
        {
            int swap = collection[i];
            collection[i] = collection[swapIndex];
            collection[swapIndex] = swap;
        }
    }
}
