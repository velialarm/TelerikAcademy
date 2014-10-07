using System;

/// <summary>
/// Write a program that reads 3 integer numbers from the console and prints their sum.
/// </summary>
class Program
{
    static void Main()
    {
        Console.Write("Enter first digit: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second digit: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter third digit: ");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}+{1}+{2}={3}", a, b, c, a + b + c);
    }
}

