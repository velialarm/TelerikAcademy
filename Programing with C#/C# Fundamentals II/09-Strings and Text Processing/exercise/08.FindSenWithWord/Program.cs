//Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text;
class Program
{
    static void Main()
    {
        string message = @"We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string searchWord = "in";
        char[] separate = {'.'};
        string[] sentences = message.Split(separate,StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new StringBuilder();
        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(' ');
            foreach (var word in words)
            {
                if (word==searchWord)
                {
                    sb.AppendFormat("{0}.", sentence);
                    break;
                    //Console.WriteLine(sentence);
                }
            }
            
        }
        Console.WriteLine(sb.ToString());

    }
}
