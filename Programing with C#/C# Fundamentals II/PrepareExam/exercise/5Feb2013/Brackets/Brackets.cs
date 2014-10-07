using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Brackets
{
    private static StringBuilder sb = new StringBuilder();
    private static string tabs;
    private static int tabsCount = 0;
    private static bool shouldprintNewLine = false;
    private static bool firstSymbol = true;
    static void Main(string[] args)
    {
        //read
        //hardcore
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        int n = int.Parse(Console.ReadLine());
        tabs = Console.ReadLine();

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            HandleLine(line);
        }
        Console.WriteLine(sb.ToString());
    }

    private static void HandleLine(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (shouldprintNewLine)
            {
                if (!firstSymbol)
                {
                    sb.AppendLine();
                    shouldprintNewLine = false;
                    firstSymbol = true;
                }
            }

            char currentCharacter = line[i];

            if (currentCharacter == '{')
            {
                sb.AppendLine();
                AppendTabs();
                sb.Append(currentCharacter);
                tabsCount++;
                shouldprintNewLine = true;
            }
            else if (currentCharacter == '}')
            {
                tabsCount--;
                sb.AppendLine();
                AppendTabs();
                sb.Append(currentCharacter);
                shouldprintNewLine = true;
            }
            else 
            {
                if (firstSymbol)
                {
                    AppendTabs();
                }
                if (!(firstSymbol && char.IsWhiteSpace(currentCharacter)))
                {
                    if (!(i<line.Length-1
                        && char.IsWhiteSpace(line[i])
                        && char.IsWhiteSpace(line[i+1])))
                    {
                    sb.Append(currentCharacter);
                    firstSymbol = false;
                    }
                }
             
            }
        }
    }
    private static void AppendTabs(){
        for (int i = 0; i < tabsCount; i++)
        {
            sb.Append(tabs);
        }
    }
}

