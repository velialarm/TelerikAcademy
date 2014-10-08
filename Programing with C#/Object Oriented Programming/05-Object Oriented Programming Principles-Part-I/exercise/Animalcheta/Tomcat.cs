using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animalcheta
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, Sex.male, age)
        {
            
        }
    }
}
