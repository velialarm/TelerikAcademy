//Write a program that replaces in a HTML document given as string all the tags
//<a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
using System;
using System.Text;
class Program
{
    static void Main()
    {
        string input = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string start = "<a href=";
        string end = "</a>";
        int index = -1;
        int befPos = 0;
        bool afterCheck = false;
        int closeTagPos = 0;
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            index = input.IndexOf(start,index+1);
            if (index == -1)
	        {
                if (afterCheck)
                {
                    string after = input.Substring(closeTagPos + end.Length, input.Length - (closeTagPos + end.Length));
                    sb.Append(after);
                }
		         break;
	        }
            afterCheck = true;
            string before = input.Substring(befPos,index-befPos);
            sb.Append(before);
            //Console.Write(before);
            
            int endPos = input.IndexOf(">", index);
            string openTag = input.Substring(index,endPos-index+1);

            sb.Append("[URL=");
            sb.Append(openTag.Substring(9, openTag.Length - 11));
            sb.Append("]");

            closeTagPos = input.IndexOf(end,endPos);
            befPos = closeTagPos+end.Length;
            
            string between = input.Substring(endPos+1,closeTagPos-endPos-1);

            sb.Append(between);

            sb.Append("[/URL]");
        }
        Console.WriteLine(sb.ToString());
    }
}