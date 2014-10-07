using System;
using System.Text;
class ForbidenWords
{
    static void Main()
    {
        string message = @"Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR";
        string forbWords = "PHP, CLR, Microsoft";
        string[] wordsAll = message.Split(' ');
        string[] forbiden = forbWords.Split(' ', '.',',');
        StringBuilder sb = new StringBuilder();
        foreach (var word in wordsAll)
        {
            int found = 0;
            for (int i = 0; i < forbiden.Length; i++)
            {
                if (word == forbiden[i])
                {
                    string newword = String.Empty;
                    string res = word.Replace(word, newword.PadRight(word.Length, '*'));
                    sb.AppendFormat("{0} ", res);
                    found++;              
                }        
            }
            if (found==0)
            {
                sb.AppendFormat("{0} ", word);
            }
        }
        Console.WriteLine(sb);
    }
}
