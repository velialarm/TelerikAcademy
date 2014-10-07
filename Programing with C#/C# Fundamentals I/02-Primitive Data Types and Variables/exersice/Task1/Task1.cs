using System;

class Task1
    {
        static void Main()
        {
            //Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, 
            //int, uint, long, ulong to represent the following values: 52130, -115, 4825932, 97, -10000.

            ushort value1 = 52130; // 0 to 65535 : unsigned 16 bit
            sbyte value2 = -115;  // -128 to 127 : signed 8-bit
            int value3 = 4825932; // -2147483648 to 2147483647 : signed 32 bit
            byte value4 = 97;  // 0 to 255 : unsigned 8 bit
            short value5 = -10000; // -32768 to 32767 :signed 16 bit

            Console.WriteLine("{0} is ushort \n {1} is sbyte \n {2} is int \n {3} is byte \n {4} is short",value1,value2,value3,value4,value5);
        }
    }

