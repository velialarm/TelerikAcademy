namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 14.*  Task
    /// We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
    /// We can move from an empty cell to another empty cell if they share common wall. 
    /// Given a starting position (*) calculate and fill in the array the minimal distance from this position to any other cell in the array. 
    /// Use "u" for all unreachable cells.
    /// </summary>
    static class Labyrinth
    {
        static readonly ICollection<Coordinates> Directions = new Coordinates[]
    {
        new Coordinates( 0,  1),
        new Coordinates( 1,  0),
        new Coordinates( 0, -1),
        new Coordinates(-1,  0),
    };

        static void Main(string[] args)
        {
            string[,] labyrinth =  
        {
            { "_", "_", "_", "#", "_", "#" },
            { "_", "#", "_", "#", "_", "#" },
            { "_", "X", "#", "_", "#", "_" },
            { "_", "#", "_", "_", "_", "_" },
            { "_", "_", "_", "#", "#", "_" },
            { "_", "_", "_", "#", "_", "#" },
        };

            var currentQueue = new Queue<Coordinates>();
            currentQueue.Enqueue(labyrinth.GetIndex("X"));

            int level = 0;
            while (currentQueue.Count != 0)
            {
                var nextQueue = new Queue<Coordinates>();
                level++;
                while (currentQueue.Count != 0)
                {
                    Coordinates currentCoordinates = currentQueue.Dequeue();
                    foreach (Coordinates currentDirection in Directions)
                    {
                        Coordinates nextCoordinates = currentCoordinates + currentDirection;
                        if (!labyrinth.IsInRange(nextCoordinates))
                        {
                            continue;
                        }
                        if (labyrinth[nextCoordinates.Row, nextCoordinates.Col] != "_")
                        {
                            continue;
                        }
                        labyrinth[nextCoordinates.Row, nextCoordinates.Col] = level.ToString();
                        nextQueue.Enqueue(nextCoordinates);
                    }
                }

                currentQueue = nextQueue;
            }
            Console.WriteLine(labyrinth.Replace("_", "0").AsString());
        }

        static Coordinates GetIndex<T>(this T[,] matrix, T element)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(element))
                    {
                        return new Coordinates(row, col);
                    }
                }
            }
            throw new ArgumentException("Invalid element.");
        }

        static bool IsInRange<T>(this T[,] matrix, Coordinates coordinates)
        {
            return (0 <= coordinates.Row) && (coordinates.Row < matrix.GetLength(0)) &&
                   (0 <= coordinates.Col) && (coordinates.Col < matrix.GetLength(1));
        }

        static T[,] Replace<T>(this T[,] matrix, T oldValue, T newValue)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(oldValue))
                    {
                        matrix[row, col] = newValue;
                    }
                }
            }
            return matrix;
        }

        static string AsString<T>(this T[,] matrix)
        {
            var result = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.Append(matrix[row, col] + (col != matrix.GetUpperBound(1) ? " " : Environment.NewLine));
                }
            }
            return result.ToString().TrimEnd();
        }
    }

    struct Coordinates
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Coordinates(int row, int col) : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b)
        {
            return new Coordinates(
                a.Row + b.Row,
                a.Col + b.Col
            );
        }

        public static Coordinates operator -(Coordinates a, Coordinates b)
        {
            return new Coordinates(
                a.Row - b.Row,
                a.Col - b.Col
            );
        }
    }
}
