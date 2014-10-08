/**
 * Implement an extension method Substring(int index, int length) for the class 
 * StringBuilder that returns new StringBuilder and has the same 
 * functionality as Substring in the class String.
 */

using System;
using System.Text;

namespace ExtensionMethod
{
    public static class MyStringBuilder
    {
        public static String Text { get; set; }      
        public static String SubString(int index, int lenght)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Text);
            str.Remove(0, index);
            str.Remove(lenght - index+1, str.Length-2);
            return str.ToString();
        }

    }
}
