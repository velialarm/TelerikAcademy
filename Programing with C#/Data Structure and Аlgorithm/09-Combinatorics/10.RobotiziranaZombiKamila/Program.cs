using System;
using System.Linq;

struct Coordinates
{
    public int Row { get; private set; }
    public int Col { get; private set; }

    public static readonly Coordinates Zero = new Coordinates();

    public Coordinates(int row, int col)
        : this()
    {
        this.Row = row;
        this.Col = col;
    }

    public static int Distance(Coordinates a, Coordinates b)
    {
        return Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Row, this.Col);
    }
}

class Program
{
    static void Main()
    {
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));

        var input = Enumerable.Range(0, int.Parse(Console.ReadLine()) * 2)
            .Select(i => Console.ReadLine())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        var distances = input
            .Select(line => line.Split())
            .Select(match =>
                new Coordinates(int.Parse(match[0]), int.Parse(match[1]))
            ).Select(coord =>
                Coordinates.Distance(coord, Coordinates.Zero)
            ).ToArray();

        ulong result = 0;

        foreach (var dist in distances)
        {
            result += (ulong)dist * (ulong)Math.Pow(2, distances.Length - 1);
        }

        Console.WriteLine(result);
    }
}
