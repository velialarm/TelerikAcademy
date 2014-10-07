//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags
using System;
using System.Text;
    class Program
    {
        static void Main()
        {
            string html = @"<html>
                    <head><title>News</title></head>
                    <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body>
                    </html>";
            int startTitle = html.IndexOf("<title>");
            if (startTitle != -1)
            {
                string titleTag = "</title>";
                int endTitle = html.IndexOf(titleTag) ;
                string title = html.Substring(startTitle+titleTag.Length-1,endTitle-startTitle-titleTag.Length+1);
                Console.WriteLine(title);
            }
            string bodyTag = "<body>";
            int startBody = html.IndexOf(bodyTag);
            if (startBody!=-1)
            {
                string endBodyTag = "</body>";
                int endBody = html.IndexOf(endBodyTag);
                string body = html.Substring(startBody+bodyTag.Length,endBody-startBody-endBodyTag.Length+1);
                //remove all tags
                StringBuilder sb = new StringBuilder();
                int index = -1;
                int startPos = 0;
                int endPos = 0;
                while (true)
                {
                    index = body.IndexOf("<", index + 1);
                    if (index==-1)
                    {
                        break;
                    }
                    if (startPos==index)
                    {
                        endPos = body.IndexOf(">", index);
                        startPos = endPos + 1;
                        continue;
                    }
                    string print = body.Substring(startPos,index-startPos);
                    sb.Append(print);
                    sb.Append(" ");
                    endPos = body.IndexOf(">",index);
                    startPos = endPos+1;
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
