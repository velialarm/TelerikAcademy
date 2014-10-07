using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Trails3D
{
    static void Main(string[] args)
    {
        if (File.Exists("inpit.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }


    }
}

