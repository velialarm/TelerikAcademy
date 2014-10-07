using System;

    class Task2
    {
        static void Main()
        {
            //Which of the following values can be assigned to a variable of type float and which to a variable of type double: 
            // 34.567839023, 12.345, 8923.1234857, 3456.091?


            double value1 = 34.567839023; 
            float value2 = 12.345f;
            double value3 = 8923.1234857;
            float value4 = 3456.091f;

            Console.WriteLine("{0} is double \n {1} is float \n {2} is double \n {3} is float",value1,value2,value3,value4);
        }
    }
