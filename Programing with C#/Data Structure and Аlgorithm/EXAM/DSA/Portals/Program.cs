using System;
using System.Collections.Generic;
using System.IO;

namespace Portals
{
    class Program
    {
        static void Main()
        {
            Console.SetIn(new StreamReader("../../input.txt"));  //TODO comment me before send in BGCODER

            string[] startingLocation = Console.ReadLine().Split(' ');
            int startingRow = int.Parse(startingLocation[0]);
            int startingCol = int.Parse(startingLocation[1]);
            var startCube = new Cube<int>(startingRow, startingCol, 0);

            string[] labirintDimension = Console.ReadLine().Split(' ');
            int rows = int.Parse(labirintDimension[0]);
            int columns = int.Parse(labirintDimension[1]);

            var used = new HashSet<Cube<int>>();
            var labirinth = new int[rows, columns];
            //a descriptions of an RxC matrix
            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                var cubes = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cubes.Length; j++)
                {

                    if (cubes[j] == "#")
                    {
                        labirinth[i, j] = -9999;
                        used.Add(new Cube<int>(i, j, -1));
                    }
                    else
                    {
                        labirinth[i, j] = int.Parse(cubes[j]) - 1;
                    }

                }
            }

            var queue = new Queue<Cube<int>>();
            queue.Enqueue(startCube);
            used.Add(startCube);

            //maximum sum of teleportation power one can use 
            int max = labirinth[startCube.Row, startCube.Column]+1;
            //            int max = labirinth[startCube.Row, startCube.Column] + 1;
            bool opa = true;
            while (queue.Count > 0)
            {
                //TODO

                var currentCube = queue.Dequeue();
                int currentValue = labirinth[currentCube.Row, currentCube.Column] + 1;
                // exitfrom labirint
                if (currentCube.Row > rows || currentCube.Column > columns || currentCube.Row < 0 || currentCube.Column < 0 || currentValue < 0)
                {
                    continue;
                }
                
                int curCubePower = currentValue;

                Console.WriteLine(curCubePower);
                //max += curCubePower;

                //UP
                if (currentCube.Row - curCubePower > 0)
                {
                    var newCelDim = currentCube.Row - curCubePower;
                    var newCube = new Cube<int>(newCelDim, currentCube.Column, currentCube.QueueLevel + 1);
                    var val = labirinth[newCube.Row, newCube.Column] + 1;
                    if (!(used.Contains(newCube) && val > 0))
                    {
//                        max += val;
//                        Console.WriteLine("Up {0} - sum: {1} - celValue: {2}", newCelDim, max, val);
                        queue.Enqueue(newCube);
                        used.Add(newCube);
                    }
                }

                //DOWN
                if (currentCube.Row + curCubePower < rows-1)
                {
                    var newCelDim = currentCube.Row + curCubePower;
                    var newCube = new Cube<int>(newCelDim, currentCube.Column, currentCube.QueueLevel + 1);
                    var val = labirinth[newCube.Row, newCube.Column] + 1;
                    if (!(used.Contains(newCube) && val > 0))
                    {
//                        max += val;
//                        Console.WriteLine("Down {0} - sum: {1} - celValue: {2}", newCelDim, max, val);
                        queue.Enqueue(newCube);
                        used.Add(newCube);
                    }
                }

                //Left
                if (currentCube.Column - curCubePower > 0)
                {
                    var newCelDim = currentCube.Column - curCubePower;
                    var newCube = new Cube<int>(currentCube.Row, newCelDim, currentCube.QueueLevel + 1);
                    var val = labirinth[newCube.Row, newCube.Column] + 1;
                    if (!(used.Contains(newCube) && val > 0))
                    {
//                        max += val;
//                        Console.WriteLine("Left {0} - sum: {1} - celValue: {2}", newCelDim, max, val);
                        queue.Enqueue(newCube);
                        used.Add(newCube);

                    }
                }

                //Right
                if (currentCube.Column + curCubePower < columns-1)
                {
                    var newCelDim = currentCube.Column + curCubePower;
                    var newCube = new Cube<int>(currentCube.Row, newCelDim, currentCube.QueueLevel + 1);
                    var val = labirinth[newCube.Row, newCube.Column] + 1;
                    if (!(used.Contains(newCube) && val > 0))
                    {
//                        max += val;
//                        Console.WriteLine("Right {0} - sum: {1} - celValue: {2}", newCelDim, max, val);
                        queue.Enqueue(newCube);
                        used.Add(newCube);
                    }
                }
                if (opa)
                {
                    opa = false;
                }
                else
                {
                    if (currentCube.QueueLevel == 0)
                    {
                        Environment.Exit(0);
                    }
                }
               
            }
            Console.WriteLine(max);
        }

        public class Cube<T>
        {
            public Cube(T row, T column, int queueLevel)
            {
                this.Row = row;
                this.Column = column;
                this.QueueLevel = queueLevel;
            }

            public T Row { get; set; }

            public T Column { get; set; }

            public int QueueLevel { get; set; }

            public override bool Equals(object obj)
            {
                var otherCell = obj as Cube<T>;
                if (otherCell == null)
                {
                    return false;
                }

                return this.Row.Equals(otherCell.Row)
                    && this.Column.Equals(otherCell.Column);
            }

            public override int GetHashCode()
            {
                return this.Row.GetHashCode() ^
                        this.QueueLevel.GetHashCode()^
                        this.Column.GetHashCode();
            }
        }
    }
}
