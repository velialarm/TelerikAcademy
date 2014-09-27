using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Implement the data structure linked list. Define a class ListItem<T> that has two fields: value (of type T) and  NextItem (of type ListItem<T>). Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).



public class ListItem<T>
{
    public T Value { get; set; }
    public ListItem<T> NextItem { get; set; }
}
class LinkedList<T>
{
    public ListItem<T> FirstElement { get; set; }
}

   class Program
    {
      

        static void Main(string[] args)
        {

        }
    }
