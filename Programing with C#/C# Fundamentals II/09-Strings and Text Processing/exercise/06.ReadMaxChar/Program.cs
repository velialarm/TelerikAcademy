//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
//Print the result string into the console.

using System;
class ReadMaxChar
{
    static void Main()
    {
        Console.WriteLine("Enter string: ");
        string input = Console.ReadLine();
        if (input.Length>20)
        {
            Console.WriteLine("You enter more than 20 characters.");
            return;
        }
        Console.WriteLine(input.PadRight(20,'*'));
    }
}
