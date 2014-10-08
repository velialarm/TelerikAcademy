using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    class InvalidRangeExeption<T> : ApplicationException
    {
        public T Start { get; set; }
        public T End { get; set; }

        public InvalidRangeExeption() { }
        public InvalidRangeExeption(string text, T start, T end):base(text) {
            this.Start = start;
            this.End = end;
        }
    }
}
