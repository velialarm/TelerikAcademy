namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///  * 10 Taks.
    /// We are given numbers N and M and the following operations:
    /// a)N = N+1
    /// b)N = N+2
    /// c)N = N*2
    /// Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
    /// Example: N = 5, M = 16
    /// Sequence: 5 7 8 16
    /// </summary>
    class FindShortesSequence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            string inputLine = Console.ReadLine();
            int firstElement = int.Parse(inputLine);
            LinkedList<int> firstList = new LinkedList<int>();
            firstList.AddLast(firstElement);
            Queue<LinkedList<int>> solutions = new Queue<LinkedList<int>>();
            solutions.Enqueue(firstList);
            Console.Write("Enter M: ");
            inputLine = Console.ReadLine();
            int numberM = int.Parse(inputLine);
            LinkedList<int> result = FindMinOperations(solutions, numberM);
            Console.Write("Result: ");
            while (result.Count > 0)
            {
                LinkedListNode<int> tempNode = result.First;
                if (tempNode.Next != null)
                {
                    Console.Write("{0}->", tempNode.Value);
                    result.RemoveFirst();
                }
                else
                {
                    Console.WriteLine("{0}.", tempNode.Value);
                    result.RemoveFirst();
                }
            }
            Console.Read();
        }

        static LinkedList<int> FindMinOperations(Queue<LinkedList<int>> queueList, int M)
        {
            while (true)
            {
                LinkedList<int> currentList = queueList.Dequeue();
                LinkedListNode<int> currentLastElement = currentList.Last;

                int firstNextValue = currentLastElement.Value + 1;
                LinkedList<int> firstNextList = new LinkedList<int>(currentList);
                firstNextList.AddLast(firstNextValue);
                if (firstNextValue < M)
                {
                    queueList.Enqueue(firstNextList);
                }
                else if (firstNextValue == M)
                {
                    queueList.Enqueue(firstNextList);
                    return firstNextList;
                }
                int secondNextValue = currentLastElement.Value + 2;
                LinkedList<int> secondNextList = new LinkedList<int>(currentList);
                secondNextList.AddLast(secondNextValue);
                if (secondNextValue < M)
                {
                    queueList.Enqueue(secondNextList);
                }
                else if (secondNextValue == M)
                {
                    queueList.Enqueue(secondNextList);
                    return secondNextList;
                }
                int thirdNextValue = currentLastElement.Value * 2;
                LinkedList<int> thirdNextList = new LinkedList<int>(currentList);
                thirdNextList.AddLast(thirdNextValue);
                if (thirdNextValue < M)
                {
                    queueList.Enqueue(thirdNextList);
                }
                else if (thirdNextValue == M)
                {
                    queueList.Enqueue(thirdNextList);
                    return thirdNextList;
                }
            }
        }
    }
}
