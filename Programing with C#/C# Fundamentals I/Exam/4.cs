﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2 + 1;
            int height = 6+((n-3)/2)*3;

            //for performance :)
            //StringBuilder sb = new StringBuilder();

            //first row
            int part = (width-n) / 2;
            Console.Write(new string('.',part));
            Console.Write(new string('*',n));
            Console.Write(new string('.', part));
            Console.WriteLine();
            //head part
            int ost = height - n - 1;
            for (int i = 1; i < ost; i++)
            {
                Console.Write(new string('.', part-i));
                Console.Write("*");
                Console.Write(new string('.', ost+i-2));
                Console.Write("*");
                Console.Write(new string('.', ost + i - 2));
                Console.Write("*");
                Console.Write(new string('.', part - i));
                Console.WriteLine();
            }

            Console.WriteLine(new string('*',width));

            //bottom part
            for (int i = 0; i < n; i++)
            {
                
                Console.Write(new string('.',i+1) );
                //Console.Write(new string('.',width/2));
                Console.Write("*");
                if ((n - i - 2) >= 0) {
                    Console.Write(new string('.', n - i - 2));
                    Console.Write("*");
                }
                if ((n - i - 2) >= 0)
                {
                    Console.Write(new string('.', n - i-2));
                    Console.Write("*");
                }
                Console.Write(new string('.', i + 1));
                Console.WriteLine();
            }
        }
    }
