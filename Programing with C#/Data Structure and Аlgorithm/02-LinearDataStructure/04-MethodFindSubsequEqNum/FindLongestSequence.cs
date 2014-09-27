namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 4. Task
    /// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly.
    /// </summary>
    class FindLongestSequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sequence in one line of numbers with space between them: ");
            string input = Console.ReadLine();
            string[] elements = input.Split(' ');
            List<int> elem = new List<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                elem.Add(int.Parse(elements[i]));
            }

            List<int> outputList = FindLongestSubSequence(elem);

            for (int i = 0; i < outputList.Count; i++)
            {
                Console.Write("{0} ", outputList[i]);
            }

            Console.Read();
        }
        public static List<int> FindLongestSubSequence(List<int> check)
        {
            List<int> result = new List<int>();
            int currentIndex = 0;
            int bestIndex = int.MinValue;
            int currentLength = 1;
            int bestLength = 0;
            for (int i = 1; i < check.Count; i++)
            {
                if (check[currentIndex] == check[i])
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestIndex = currentIndex;
                    }
                    currentIndex = i;
                    currentLength = 1;
                }
                if (i == check.Count - 1)
                {
                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestIndex = currentIndex;
                    }
                }
            }
            for (int i = 0; i < bestLength; i++)
            {
                int tempElement = check[i + bestIndex];
                result.Add(tempElement);
            }

            return result;

        }
    }
}