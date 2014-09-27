namespace LinearDataStructuresHomework
{
    using System.Collections.Generic;

    /// <summary>
    /// Define additionally a class LinkedList<T>with a single field FirstElement(of type ListItem<T>).
    /// </summary>
    public class CustomLinkedList<T> : LinkedList<T>
    {
        public CustomListItem<T> FirstElement { get; set; }
    }
}
