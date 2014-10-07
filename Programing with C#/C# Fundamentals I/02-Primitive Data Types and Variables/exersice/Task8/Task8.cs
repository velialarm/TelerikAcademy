using System;

    class Task8
    {
        static void Main()
        {
            //Declare two string variables and assign them with following value:
            //The "use" of quotations causes difficulties.
	        //Do the above in two different ways: with and without using quoted strings.

            string text1 = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(text1);

            string text2 = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(text2);

        }
    }
