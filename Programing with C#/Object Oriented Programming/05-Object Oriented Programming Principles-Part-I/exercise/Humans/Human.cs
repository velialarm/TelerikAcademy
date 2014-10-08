using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humans
{
    public abstract class Human
    {
        private String firstName;
        private String lastName;

        public Human(String firstName,String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

    }
}
