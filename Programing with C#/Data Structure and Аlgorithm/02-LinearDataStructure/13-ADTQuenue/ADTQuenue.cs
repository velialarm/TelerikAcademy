namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    class ADTQuenue<T> : IEnumerable<T>
    {
        private LinkedList<T> elements = new LinkedList<T>();

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return this.elements.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T value = this.elements.First.Value;
            this.elements.RemoveFirst();
            return value;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(" ", this);
        }
    }
}
