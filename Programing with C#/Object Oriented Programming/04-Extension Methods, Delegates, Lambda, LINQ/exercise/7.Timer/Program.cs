using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7.Timer
{

    /**
     * Using delegates write a class Timer that has can execute certain method at each t seconds.
     */
    class Program
    {
        static void Main(string[] args)
        {
            SetInterval(new Action(() =>Console.WriteLine(DateTime.Now)), 1);
        }
        static void SetInterval(Action action, int intervalTime)
        {
            while (true)
            {
                Thread.Sleep(intervalTime * 1000);

                action();
            }
        }
    }
}
