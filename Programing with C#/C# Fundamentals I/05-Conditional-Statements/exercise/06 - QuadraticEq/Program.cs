using System;

    class Program
    {
        static void Main()
        {
            //Write a program that enters the coefficients a, b and c of a quadratic equation
		    // a*x2 + b*x + c = 0
		    // and calculates and prints its real roots. 
            // Note that quadratic equations may have 0, 1 or 2 real roots.


            Console.Write("Enter a ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter b ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter c ");
            double c = double.Parse(Console.ReadLine());

            double descr = b * b - 4 * a * c;

            double x, x1, x2;

            if (a == 0)
            {
                Console.WriteLine("One real root \n x1: {0}", -c / b);
            }
            else if (descr > 0)
            {
                x1 = (-b + Math.Sqrt(descr)) / (2 * a);
                x2 = (-b - Math.Sqrt(descr)) / (2 * a);
                Console.WriteLine("x1: {0}", x1);
                Console.WriteLine("x2: {0}", x2);
            }
            else if (descr < 0)
            {
                Console.WriteLine("no root");
            }
            else if (descr == 0)
            { 
               x = -b / (2 * a);
               Console.WriteLine("x: ",x);
            }


        }
    }
