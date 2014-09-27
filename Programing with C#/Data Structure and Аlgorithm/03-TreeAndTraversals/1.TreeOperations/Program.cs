using System;
using System.Linq;
using System.Collections.Generic;
using Tree = Wintellect.PowerCollections.OrderedMultiDictionary<int, int>;

static class Program
{
    static Tree tree = new Tree(true);

    static int size = 0;

    static ICollection<T> Filter<T>(ICollection<T> source, params ICollection<T>[] collections)
    {
        var all = new HashSet<T>(source);

        foreach (var collection in collections)
        {
            all.SymmetricExceptWith(collection);
        }
        return all.ToArray();
    }

    static ICollection<int> FindAllNodes()
    {
        return Enumerable.Range(0, size).ToArray();
    }

    static ICollection<int> FindParents()
    {
        return tree.Keys;
    }

    static ICollection<int> FindChildren()
    {
        return tree.Values;
    }

    static ICollection<int> FindRoots()
    {
        return Filter(FindAllNodes(), FindChildren());
    }

    static ICollection<int> FindLeaves()
    {
        return Filter(FindAllNodes(), FindParents());
    }

    static ICollection<int> FindMiddleNodes()
    {
        return Filter(FindParents(), FindRoots());
    }

    static IList<int> ReverseTree()
    {
        var parents = new int[FindAllNodes().Count];

        var queue = new Queue<int>();

        int root = FindRoots().First();

        parents[root] = -1;
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();

            foreach (int nextNode in tree[currentNode])
            {
                parents[nextNode] = currentNode;
                queue.Enqueue(nextNode);
            }
        }

        return parents;
    }

    static ICollection<IList<int>> FindLongestPaths()
    {
        var currentQueue = new Queue<int>();

        int root = FindRoots().First();

        currentQueue.Enqueue(root);

        Queue<int> previousQueue = null;

        while (currentQueue.Count != 0)
        {
            var nextQueue = new Queue<int>();

            foreach (int currentNode in currentQueue)
                foreach (int nextNode in tree[currentNode])
                    nextQueue.Enqueue(nextNode);

            previousQueue = currentQueue;
            currentQueue = nextQueue;
        }

        var parents = ReverseTree();

        return previousQueue.Select(node =>
        {
            var path = new Stack<int>();

            for (; node != -1; node = parents[node])
                path.Push(node);

            return path.ToArray();
        }).ToArray();
    }

    // TODO: Optimize
    static ICollection<IList<int>> FindAllPathsWithSum(int sum)
    {
        var results = new List<IList<int>>();

        foreach (int root in FindAllNodes())
        {
            var currentQueue = new Queue<IList<int>>();
            currentQueue.Enqueue(new List<int> { root });

            while (currentQueue.Count != 0)
            {
                var currentPath = currentQueue.Dequeue();

                if (currentPath.Sum() > sum)
                    continue;

                if (currentPath.Sum() == sum)
                    results.Add(currentPath);

                foreach (var nextNode in tree[currentPath.Last()])
                    currentQueue.Enqueue(new List<int>(currentPath) { nextNode });
            }
        }

        return results;
    }

    static ICollection<Tree> FindAllSubTreesWithSum(int sum)
    {
        var results = new List<Tree>();

        foreach (int root in FindAllNodes())
        {
            var currentQueue = new Queue<Tuple<Tree, int>>();
            currentQueue.Enqueue(new Tuple<Tree, int>(
                new Tree(true) { new KeyValuePair<int, ICollection<int>>(root, new int[0]) },
                root
            ));

            while (currentQueue.Count != 0)
            {
                var current = currentQueue.Dequeue();
                if (current.Item2 > sum) { 
                    continue;
                }
                if (current.Item2 == sum) { 
                    results.Add(current.Item1);
                }

                foreach (var nextNode in CombinationGenerator.Generate())
                {
                    var nextTree = current.Item1.Clone();
                }
            }
        }

        return results;
    }

    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        size = int.Parse(Console.ReadLine());
        var edges = Enumerable.Range(0, size - 1)
            .Select(i => Console.ReadLine().Split().Select(int.Parse).ToArray())
            .ToArray();

        foreach (var tuple in edges)
        {
            tree.Add(tuple[0], tuple[1]);
        }
        Console.WriteLine("TREE:");
        Console.WriteLine("All Nodes: {0}", string.Join(" ", FindAllNodes()));
        Console.WriteLine(string.Join(Environment.NewLine, tree));
        Console.WriteLine();

        Console.WriteLine("ROOTS");
        Console.WriteLine("Children: {0}", string.Join(" ", tree.Values));
        Console.WriteLine("Roots: {0}", string.Join(" ", FindRoots()));
        Console.WriteLine();

        Console.WriteLine("LEAVES");
        Console.WriteLine("Parents: {0}", string.Join(" ", tree.Keys));
        Console.WriteLine("Leaves: {0}", string.Join(" ", FindLeaves()));
        Console.WriteLine();

        Console.WriteLine("MIDDLE NODES");
        Console.WriteLine("Middle Nodes: {0}", string.Join(" ", FindMiddleNodes()));
        Console.WriteLine();

        Console.WriteLine("LONGEST PATHS");
        foreach (var path in FindLongestPaths())
        {
            Console.WriteLine(string.Join(" ", path));
        }
        Console.WriteLine();

        Console.WriteLine("PATHS WITH GIVEN SUM");
        foreach (var path in FindAllPathsWithSum(6))
        {
            Console.WriteLine(string.Join(" ", path));
        }
        Console.WriteLine();

        Console.WriteLine("SUBTREES WITH GIVEN SUM");
        foreach (var currentTree in FindAllSubTreesWithSum(6))
        {
            Console.WriteLine(string.Join(Environment.NewLine, currentTree));
        }

        Console.WriteLine();

    }
}
