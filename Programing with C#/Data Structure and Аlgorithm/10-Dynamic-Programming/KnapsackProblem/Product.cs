namespace Knapsack
{
    using System;

    public class Product : IComparable
    {
        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Cost { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Weight: {1}, Cost: {2}", this.Name, this.Weight, this.Cost);
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}