using System.Collections.Generic;

namespace _01MobilePhones
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            GSM gsm = new GSM();
            gsm.Bat = new Battery();
        }
    }
}
