//You are given a text. 
//Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
//The tags cannot be nested. 
using System;
using System.Collections.Generic;
using System.Text;
class UpcaseTags
{
    static void Main()
    {
        string text = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string openTag = "<upcase>";
        string closeTag = "</upcase>";
        
        List<int> startIndex = new List<int>();
        SearchTags(text, openTag, startIndex);
        List<int> endindex = new List<int>();
        SearchTags(text, closeTag, endindex);
       // StringBuilder sb = new StringBuilder();
        int indBefore = 0;
        for (int i = 0; i < startIndex.Count; i++)
        {
            int lenghtBef = startIndex[i]-indBefore;
            int lenght = endindex[i] - startIndex[i] - openTag.Length;
            int start = startIndex[i] + openTag.Length;
            string res = text.Substring(start,lenght).ToUpper();
            string before = text.Substring(indBefore,lenghtBef);
            indBefore = endindex[i]+closeTag.Length;
            Console.Write("{0} - {1}",before,res);
            if (i == startIndex.Count-1)
            {
                int lenghtAfter = text.Length - endindex[i] - closeTag.Length;
                int startAfter = endindex[i]+closeTag.Length;
                string after = text.Substring(startAfter,lenghtAfter);
                Console.Write(after);
            }
        }
        Console.WriteLine();
    }
    private static void SearchTags(string text, string openTag, List<int> startIndex)
    {
        int index = -1;
        while (true)
        {
            index = text.IndexOf(openTag, index + 1);
            if (index == -1)
            {
                break;
            }
            startIndex.Add(index);
        }
    }
 

}

