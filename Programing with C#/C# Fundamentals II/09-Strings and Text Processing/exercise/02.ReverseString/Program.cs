using System;
class ReverseString
{
    static void Main()
    {
        Console.Write("Enter String: ");
        string data = Console.ReadLine();
        for (int i = 0; i < data.Length; i++)
        {
            char symbol = data[data.Length-i-1];
            Console.Write(symbol);
        }
        Console.WriteLine();
    }
}