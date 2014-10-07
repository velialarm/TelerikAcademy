using System;



    class task7
    {
        static void Main()
        {
            //Declare two string variables and assign them with “Hello” and “World”. 
            // Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
            // Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

            string variable1 = "Hello ";
            string variable2 = "world";
            object sum = variable1 + variable2;
            //Console.WriteLine(sum);
            string variable3 = (string)sum;
            Console.WriteLine(variable3);
        }
    }
