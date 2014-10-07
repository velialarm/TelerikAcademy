using System;

    class Program
    {
        static void Main()
        {
            //Write a program that reads the coefficients a, b and c of a quadratic equation 
            // ax2+bx+c=0 and solves it (prints its real roots).

            Console.Write("Enter a : ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter b : ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter c : ");
            double c = double.Parse(Console.ReadLine());

            double descr = b * b - 4 * a * c;

            double x, x1, x2;
            

            if(descr > 0){
                Console.WriteLine("Two distinct roots");
                x1 = (-b + Math.Sqrt(descr)) / (2 * a);
                Console.WriteLine("First distints is x1 = {0}",x1);
                x2 = (-b - Math.Sqrt(descr)) / (2 * a);
                Console.WriteLine("Second distints is x1 = {0}", x2);
            }
            else if (descr < 0) {
                Console.WriteLine("No real roots");
            }
            else if (descr == 0) {
                x = -b / (2 * a);
                Console.WriteLine(" there is exactly one real root x = {0}",x);
            }
            else if (a == 0) {
                Console.WriteLine("equation is not quadratic !");
            }


        }
    }
