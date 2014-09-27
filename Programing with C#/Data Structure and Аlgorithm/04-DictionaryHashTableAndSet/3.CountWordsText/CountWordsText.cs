namespace DictionaryHashTableAndSetHW
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// 3. Task
    /// Write a program that counts how many times each word from given text file words.txt appears in it. 
    /// The character casing differences should be ignored. 
    /// The result words should be ordered by their number of occurrences in the text. 
    /// 
    /// Example: This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
    /// is -> 2 
    /// the -> 2 
    /// this -> 3 
    /// text -> 6
    /// </summary>
    class CountWordsText
    {
        static void Main(string[] args)
        {
            //string text = "This is the TEXT.Text, text, text - THIS TEXT! Is this the text?";

            StreamReader reader = new StreamReader(@"../../../words.txt");
            using (reader)
            {
                string text = reader.ReadToEnd();
                IDictionary<string, int> wordsCount = new Dictionary<string, int>();
                CountWords(text, wordsCount);
            }
        }

        private static void CountWords(string text, IDictionary<string, int> wordsCount)
        {
            char[] separators = { ' ', '.', ',', '!', '–', '?', '-' };
            string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                int count = 1;
                if (wordsCount.ContainsKey(word))
                {
                    count = wordsCount[word] + 1;
                }
                wordsCount[word] = count;
            }
            foreach (var pair in wordsCount)
            {
                Console.WriteLine("{0} --> {1}", pair.Key, pair.Value);
            }
        }
    }
}