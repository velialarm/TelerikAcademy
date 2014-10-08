using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animalcheta
{
    public class Cat : Animals, ISound
    {
        public Cat(string name, Sex sex, int age)
            : base(name, sex, age)
        {
           
        }
    
        void ISound.sound()
        {
            Console.WriteLine("Say: mqyyyyy");
        }
    }
}
