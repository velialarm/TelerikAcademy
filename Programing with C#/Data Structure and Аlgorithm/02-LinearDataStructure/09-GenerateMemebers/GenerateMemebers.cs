namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 9 Task
    /// We are given the following sequence:S1= N;S2= S1+ 1;S3= 2*S1+ 1;S4= S1+ 2;S5= S2+ 1;S6= 2*S2+ 1;S7= S2+ 2;...
    /// Using the Queue<T>class write a program to print its first 50 members for given N.
    /// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    class GenerateMemebers
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);
            int count = 1;
            int lastIndex = 50;
            Console.Write("N = {0} -> ", n);
            Console.Write("{0},", n);
            while (count < lastIndex)
            {
                int currentElement = sequence.Dequeue();
                int firstNext = currentElement + 1;
                sequence.Enqueue(firstNext);
                Console.Write("{0},", firstNext);
                count++;
                if (count >= lastIndex)
                {
                    break;
                }
                int secondNext = currentElement * 2 + 1;
                sequence.Enqueue(secondNext);
                Console.Write("{0},", secondNext);
                count++;
                if (count >= lastIndex)
                {
                    break;
                }
                int thirdNext = currentElement + 2;
                sequence.Enqueue(thirdNext);
                Console.Write("{0},", thirdNext);
                count++;
                if (count >= lastIndex)
                {
                    break;
                }
            }
            Console.Read();
        }
    }
}
