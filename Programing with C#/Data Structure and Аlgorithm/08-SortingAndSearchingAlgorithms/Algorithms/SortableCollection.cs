namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 4. Task
    /// Implement SortableCollection.LinearSearch()method using linear search
    /// </summary>
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get { return this.items; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int LinearSearch(T item)
        {
            return this.Items.LinearSearch(item);
        }

        /// <summary>
        /// 5. Task
        /// Implement SortableCollection.BinarySearch()method using binary search algorithm
        /// </summary>
        public int BinarySearch(T item)
        {
            return this.Items.BinarySearch(item);
        }

        /// <summary>
        /// 6. Task
        /// Implement SortableCollection.Shuffle()method using shuffle algorithm of your choice
        /// </summary>
        public void Shuffle()
        {
            this.Items.Shuffle();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}