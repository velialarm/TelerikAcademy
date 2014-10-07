using System;

    class Program
    {
        static void Main()
        {

            //Write a program that reads two positive integer numbers 
            //and prints how many numbers p exist between them such that the reminder 
            //of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            int p = 0; //how many time ...

            while (a <= b) { 
                if(a % 5 ==0){
                    p++;
                }
                a++;
            }

            Console.WriteLine("Number exist between first and second digit: {0}",p);

        }
    }
