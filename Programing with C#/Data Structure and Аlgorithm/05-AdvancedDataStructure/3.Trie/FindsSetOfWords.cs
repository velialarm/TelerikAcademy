namespace Trie
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using rmandvikar.Trie;

    /// <summary>
    /// 3. Task
    /// Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). 
    /// Print how many times each word occurs in the text. 
    /// Hint: you may find a C# trie in Internet.
    /// </summary>
    class FindsSetOfWords
    {
        static ICollection<string> GetWords()
        {
            using (var input = new StreamReader("../../input.txt"))
            {
                var words = new List<string>();
                for (string line = null; (line = input.ReadLine()) != null; )
                {
                    var currentWords = Regex.Matches(line, @"[a-zA-Z]+").Cast<Match>().Select(match => match.Value).ToArray();
                    words.AddRange(currentWords.Select(word => word.ToLower()));
                }
                return words;
            }
        }

        static void Main()
        {
            var date = DateTime.Now;
            var words = GetWords();
            Console.WriteLine(DateTime.Now - date);
            var trie = TrieFactory.GetTrie();
            foreach (var word in words)
            {
                trie.AddWord(word);
            }

            var searched = new[] { "buddhism", "wikipedia", "the", "of", "factors" };
            Console.WriteLine(string.Join(" | ", searched.Select(word => string.Format("{0} {1}", word, trie.WordCount(word)))));
        }
    }
}