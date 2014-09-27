namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 6. Task
    /// Write a program that removes from given sequence all numbers that occur odd number of times.
    /// </summary>
    class RemoveOddNum
    {
        static void Main(string[] args)
        {
            List<int> enter = new List<int>();

            Console.WriteLine("Enter digits  and we will remove that occur odd number of times. For exit press enter");
            Dictionary<int,int> result = new Dictionary<int, int>();
            while (true)
            {
                Console.Write("enter number: ");
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    break;
                }
               
                int number = int.Parse(input);
                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            List<int> resultList = new List<int>();
            foreach (var data in result)
            {
                if (data.Value %2 == 0)
                {
                    resultList.Add(data.Key);
                } 
            }

            Console.Write("All numbers that occur odd number of times are: ");
            foreach (var number in resultList)
            {
                Console.WriteLine("{0}; ",number);
            }

            Console.Read();
        }
    }
}