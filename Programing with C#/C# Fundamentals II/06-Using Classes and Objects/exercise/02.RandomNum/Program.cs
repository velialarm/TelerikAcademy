//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;
using System.Security.Cryptography;
class Program
    {
        static void Main()
        {         
            for (int i = 0; i < 10; i++)
            {
                int result = RandomNum.Generate(100, 200);
                Console.WriteLine("{0}.  {1}",i+1,result);
            }
        }
    }
public static class RandomNum
{
    private static Random Generator = new Random();
    public static int Generate(int a, int b)
    {
        int result = Generator.Next(a,b);
        return result;
    }
   
}