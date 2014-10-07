//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary. 
using System;
class Program
{
    static void Main()
    {
        string dictionary = ".NET – platform for applications from Microsoft \nCLR – managed execution environment for \n.NET namespace – hierarchical organization of classes";
        string[] lines = dictionary.Split('\n');

        Console.Write("Enter word: ");
        string word = Console.ReadLine();
        foreach (var line in lines)
        {
            int pos = line.IndexOf("–");
            if (pos!=-1)
            {
                string dictWord = line.Substring(0, pos).TrimEnd(' ');
                if (word==dictWord)
                {
                    Console.WriteLine("Description:");
                    Console.WriteLine(line.Substring(pos+1,line.Length-pos-1).TrimStart(' '));
                }
            }
            
        }
        Console.WriteLine();

    }
}
