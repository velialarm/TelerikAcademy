namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define a class ListItem<T>that has two fields: value(of type T) and NextItem(of type ListItem<T>).
    /// </summary>
    public class CustomListItem<T> : CustomLinkedList<T>
    {
        public T Value { get; set; }
        public CustomListItem<T> NextItem { get; set; }
    }
}
