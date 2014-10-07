using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class RelevanceIndex
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        SortedList<int, string> data = new SortedList<int, string>();
        List<string> lines = new List<string>();
        string[] separator = new string[] { ",", ".", "(", ")", ";", "-", "!", "?", " " };

        string searchWord = Console.ReadLine();
        int numLines = int.Parse(Console.ReadLine()); // will be no more than 100

        for (int i = 0; i < numLines; i++)
        {
            StringBuilder line = new StringBuilder();
            string[] words = Console.ReadLine().ToString().Split(separator, StringSplitOptions.RemoveEmptyEntries);//no more than 1000 characters
            int counterWord = 0;
            foreach (string word in words)
            {
                line.Append(word);
                line.Append(" ");
                if (word == searchWord)
                {
                    counterWord++;
                }
            }
            line.ToString().ToLower();
            line.Replace(searchWord, searchWord.ToUpper());
            data.Add(counterWord, line.ToString());
        }
        StringBuilder sb = new StringBuilder();
        List<string> result = new List<string>();
        foreach (var item in data)
        {
            result.Add(item.Value);
        }
        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[result.Count - i - 1]);
        }
    }
}

