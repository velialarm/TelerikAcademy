using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humans
{
    public class Students : Human
    {
        private int grade;

        public Students(String firstName, String lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
