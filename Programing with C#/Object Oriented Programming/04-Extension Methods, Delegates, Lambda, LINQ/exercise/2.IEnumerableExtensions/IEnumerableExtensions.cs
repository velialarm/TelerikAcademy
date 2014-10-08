/**
 * Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
 */


using System;
using System.Collections.Generic;

namespace _2.IEnumerableExtensions
{
    static class IEnumerableExtensions
    {
        static void Main(string[] args)
        {


        }

        private static T Reduce<T>(this IEnumerable<T> items, Func<dynamic, T, T> func, dynamic first = null)
        {
            IEnumerator<T> i = items.GetEnumerator();

            i.MoveNext();
            T previous = first ?? i.Current;

            while (i.MoveNext())
                previous = func(i.Current, previous);

            return previous;
        }
        static T Max<T>(this IEnumerable<T> items)
        {
            return items.Reduce((a, b) => a > b ? a : b);
        }

        static T Min<T>(this IEnumerable<T> items)
        {
            return items.Reduce((a, b) => a < b ? a : b);
        }

        static T Sum<T>(this IEnumerable<T> items)
        {
            return items.Reduce((a, b) => a + b);
        }

        static T Product<T>(this IEnumerable<T> items)
        {
            return items.Reduce((a, b) => a * b);
        }

        static int Count<T>(this IEnumerable<T> items)
        {
            return Convert.ToInt32(items.Reduce((a, _) => a + 1, 1));
        }
    }
    

}
