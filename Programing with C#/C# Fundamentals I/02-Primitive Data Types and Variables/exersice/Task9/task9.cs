using System;

    class task9
    {
        static void Main()
        {
            // Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
            // Use Windows Character Map to find the Unicode code of the © symbol. 
            // Note: the © symbol may be displayed incorrectly.

            var copyRight="";
            do { Console.WriteLine(copyRight); }
            while ((copyRight += '\u00a9').Length < 9);
        }
    }

