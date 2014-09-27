namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 2. Taks
    /// Write a program that reads N integers from the console and reverses them using a stack. 
    /// Use the Stack<int> class.
    /// </summary>
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Stack<int> reverse = new Stack<int>();
            Console.Write("Enter how many Number to reverse:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter integer value : ");
                try
                {
                    reverse.Push(int.Parse(Console.ReadLine()));
                }
                catch (Exception)
                {
                   throw new Exception("Invalid number");
                }
            }

            while (reverse.Count > 0)
            {
                int data = reverse.Pop();
                Console.Write("  {0}", data);
            }
            Console.ReadLine();
        }
    }
}