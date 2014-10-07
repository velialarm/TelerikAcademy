using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            //Create console application that prints your first and last name.
            Console.Write("Enter your first name: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter your last name");
            string lasttname = Console.ReadLine();
            Console.WriteLine("Your name is {0} {1}",firstname,lasttname);
        }
    }
