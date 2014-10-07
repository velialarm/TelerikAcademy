using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Basic
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        //int V = 0; int W = 0; int X = 0; int Y = 0; int Z = 0;
        string data = "";
        Dictionary<int, string> map = new Dictionary<int,string>();
        List<string> resultData = new List<string>();
        List<int> numCommandList = new List<int>();
        while (data != "RUN")
        {
            data = Console.ReadLine();
            resultData.Add(data.Trim());
        }
        for (int i = 0; i < resultData.Count-1; i++)
        {
            Console.WriteLine(resultData[i]);
            string line = resultData[i];
            int index = line.IndexOf(' ');
            if (index != -1)
            {
                string number = line.Substring(0,index);
                string command = line.Substring(index+1,line.Length-index-1).Trim();
                //clean command before add
                command = command.Replace(" ", "");
                command = command.Replace("GOTO", "GOTO ");
                command = command.Replace("PRINT", "PRINT ");
                command = command.Replace("THEN", " THEN ");
                command = command.Replace("IF", "IF ");
               // string[] commands = command.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                int numberCommand = int.Parse(number);
                map.Add(numberCommand, command);
                numCommandList.Add(numberCommand);
            }
        }

        Console.WriteLine();
        //leleeeeee
        int next = 0; ;
        StringBuilder sb = new StringBuilder();
        while (numCommandList.Count >= next+1)
        {
            string row = map[numCommandList[next]];
            int commandRow = numCommandList[next];

            if (row.IndexOf("IF") != -1)  //have IF Commands in this row
            {
                Console.WriteLine("IF.... ");
            }
            else if (row.IndexOf("GOTO") != -1)// GOTO COMMAND
            {
                Console.WriteLine("GOTO.......");
            }
            else if (row.IndexOf("PRINT") != -1) //PRINT 
            {
                Console.WriteLine("PRINT.... ");
            }
            else if (row.IndexOf("CLS") != -1)
            {
                Console.WriteLine("CLS");
            }
            else
            {
                Console.WriteLine("SMQTAIIII");
            }

            //test
           // Console.WriteLine("{0} - {1}", numCommandList[next], map[numCommandList[next]]);
            next++;
        }
        
       // Console.WriteLine("Ehoo: {0}",map[10]);

    }
}

