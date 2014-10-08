using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankata
{
    public abstract class Customers
    {
        private String name;

        public Customers(string name)
        {
            this.name = name;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
