/**
 * Implement an extension method Substring(int index, int length) for the class 
 * StringBuilder that returns new StringBuilder and has the same 
 * functionality as Substring in the class String.
 */

using System;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            String demo = "Ehooo maina kak e?"; //teks to substring 
            MyStringBuilder.Text = demo;
            String res = MyStringBuilder.SubString(1, 2);
            System.Console.WriteLine("result is: {0}",res);
            
        }
    }
}
