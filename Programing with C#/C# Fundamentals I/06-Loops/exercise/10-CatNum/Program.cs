using System;

class Program
{
    static double Factorial(double n)
    {
        // Write a program to calculate the Nth Catalan number by given N.

        double nFact = 1;
        for (double i = 1; i <= n; i++)
        {
            nFact *= i;
        }
        return nFact;
    }
    static void Main(string[] args)
    {
        Console.Write("Enter number N >= 0 : ");
        double n = int.Parse(Console.ReadLine());

        double catNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        Console.WriteLine("Catalan Number = {0}", catNumber);
    }
}
