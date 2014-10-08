using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animalcheta
{
    public class Animals
    {
        private int age;
        private string name;
        private Sex sex;

        public Animals(String name, Sex sex, int age)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Sex Sex
        {
            get { return sex; }
            set { sex = value; }
        }


        public void sound()
        {

        }

    }
}
