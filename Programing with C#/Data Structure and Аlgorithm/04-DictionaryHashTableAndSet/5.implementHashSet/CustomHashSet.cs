namespace DictionaryHashTableAndSetHW
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomHashSet<T> : IEnumerable<T>
    {
        private Dictionary<T, bool> elements = new Dictionary<T, bool>();

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Add(T value)
        {
            if (!this.Contains(value))
                this.elements.Add(value, true);
        }

        public bool Contains(T value)
        {
            return this.elements.ContainsKey(value);
        }

        public bool Remove(T value)
        {
            return this.elements.Remove(value);
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public void Union(IEnumerable<T> elements)
        {
            foreach (var element in elements)
                this.Add(element);
        }

        public void Intersect(IEnumerable<T> elements)
        {
            var other = new HashSet<T>();
            foreach (var element in elements)
                other.Add(element);

            foreach (var element in this.elements.Select(kvp => kvp.Key).ToArray())
                if (!other.Contains(element))
                    this.Remove(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.Select(kvp => kvp.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
