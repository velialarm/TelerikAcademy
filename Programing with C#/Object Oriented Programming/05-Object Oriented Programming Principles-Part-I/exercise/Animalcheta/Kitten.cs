using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animalcheta
{
    public class Kitten : Cat
    {

        public Kitten(string name, int age)
            :base(name, Sex.female, age)
        {
            
        }
    }
}
