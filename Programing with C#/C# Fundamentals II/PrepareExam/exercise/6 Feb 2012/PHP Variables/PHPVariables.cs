using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class PHPVariables
{
    private static bool multiLine = false;
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        //List<String> listLine = new List<string>();
        SortedSet<String> setVariable = new SortedSet<string>();
        // read console
        string line = "";
        while (line != "?>")
        {
            line = Console.ReadLine().Trim();
            //escape inline comments
            if (line.IndexOf("#") != -1)
            {
                continue;
            }
            int inlineComment = line.IndexOf("//");
            if (inlineComment != -1 && inlineComment == 0)
            {
                continue;
            }
            else if (inlineComment>0)
            {
                line = line.Substring(0, inlineComment);

            }
            //escape multi line comments
            bool startCommnet = line.IndexOf("/*") != -1 ? true : false;
            bool endComment = line.IndexOf("*/") != -1 ? true : false;
            if (startCommnet && !endComment)
            {
                multiLine = true;
                continue;
            }
            else if (startCommnet && endComment)
            {
                continue;
            }
           
            else if (endComment && multiLine)
            {
                multiLine = false;
            }
            else if (multiLine)
            {
                continue;
            }
            
            string[] test = line.Split(new String[] { " ", "[", "]", "(", ")", ";", "=", ",", "\"", "'", "{", "}", "#", "<?php", "?>","." }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in test)
            {
                int index = item.Trim().IndexOf("$");
                if (index != -1 && index == 0)
                {
                    setVariable.Add(item.Substring(1,item.Length-1));
                }
            }
            //listLine.Add(line);
        }

        Console.WriteLine(setVariable.Count);
        foreach (string item in setVariable)
        {
            Console.WriteLine(item);
        }


    }
}

