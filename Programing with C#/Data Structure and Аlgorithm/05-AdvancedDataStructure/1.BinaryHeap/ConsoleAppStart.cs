namespace BinaryHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ConsoleAppStart
    {
        private static void Main()
        {
            var priorityQueue = new PriorityQueue<int>();

            foreach (int i in Enumerable.Range(1, 15).Reverse())
            {
                priorityQueue.Enqueue(i);
            }

            Console.WriteLine("Peek: {0}", priorityQueue.Peek());
            Console.WriteLine("Count: {0}", priorityQueue.Count);
            Console.WriteLine(priorityQueue);

            var elements = new List<int>();
            while (priorityQueue.Count != 0)
            {
                var element = priorityQueue.Dequeue();
                elements.Add(element);
            }

            Console.WriteLine("Count: {0}", priorityQueue.Count);
            Console.WriteLine("Elements: {0}", string.Join(" ", elements));
        }
    }
}