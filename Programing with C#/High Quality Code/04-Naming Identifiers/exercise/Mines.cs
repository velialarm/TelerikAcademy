using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace minesweeper
{
    public class Mines
    {
        public class Point
        {
            string name;
            int points;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }

            public Point() { }

            public Point(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        static void Main(string[] args)
        {
            string commands = string.Empty;
            char[,] field = CreateFieldArea();
            char[,] bombs = AddBombs();
            int counts = 0;
            bool hasThrunder = false;
            List<Point> champions = new List<Point>(6);
            int red = 0;
            int col = 0;
            bool isPlayMinesweeper = true;
            const int maxNumber = 35;
            bool isOpenCells = false;

            do
            {
                if (isPlayMinesweeper)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    ShowBoard(field);
                    isPlayMinesweeper = false;
                }
                Console.Write("Daj row i kolona : ");
                commands = Console.ReadLine().Trim();
                if (commands.Length >= 3)
                {
                    if (int.TryParse(commands[0].ToString(), out red) &&
                    int.TryParse(commands[2].ToString(), out col) &&
                        red <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        commands = "turn";
                    }
                }
                switch (commands)
                {
                    case "top":
                        Rating(champions);
                        break;
                    case "restart":
                        field = CreateFieldArea();
                        bombs = AddBombs();
                        ShowBoard(field);
                        hasThrunder = false;
                        isPlayMinesweeper = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[red, col] != '*')
                        {
                            if (bombs[red, col] == '-')
                            {
                                InMoveOrder(field, bombs, red, col);
                                counts++;
                            }
                            if (maxNumber == counts)
                            {
                                isOpenCells = true;
                            }
                            else
                            {
                                ShowBoard(field);
                            }
                        }
                        else
                        {
                            hasThrunder = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (hasThrunder)
                {
                    ShowBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counts);
                    string nickname = Console.ReadLine();
                    Point pointForNewNickname = new Point(nickname, counts);
                    if (champions.Count < 5)
                    {
                        champions.Add(pointForNewNickname);
                    }
                    else
                    {
                        for (int championNumber = 0; championNumber < champions.Count; championNumber++)
                        {
                            if (champions[championNumber].Points < pointForNewNickname.Points)
                            {
                                champions.Insert(championNumber, pointForNewNickname);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Point r1, Point r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Point r1, Point r2) => r2.Points.CompareTo(r1.Points));
                    Rating(champions);

                    field = CreateFieldArea();
                    bombs = AddBombs();
                    counts = 0;
                    hasThrunder = false;
                    isPlayMinesweeper = true;
                }
                if (isOpenCells)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    ShowBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Point point = new Point(name, counts);
                    champions.Add(point);
                    Rating(champions);
                    field = CreateFieldArea();
                    bombs = AddBombs();
                    counts = 0;
                    isOpenCells = false;
                    isPlayMinesweeper = true;
                }
            }
            while (commands != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Rating(List<Point> points)
        {
            Console.WriteLine("\nTo4KI:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void InMoveOrder(char[,] fields,
            char[,] bombs, int row, int column)
        {
            char countBomb = Calculate(bombs, row, column);
            bombs[row, column] = countBomb;
            fields[row, column] = countBomb;
        }

        private static void ShowBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateFieldArea()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] AddBombs()
        {
            int columns = 5;
            int rows = 10;
            char[,] playingField = new char[columns, rows];

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> randomList = new List<int>();
            while (randomList.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomList.Contains(randomNumber))
                {
                    randomList.Add(randomNumber);
                }
            }

            foreach (int randomNumber in randomList)
            {
                int column = (randomNumber / rows);
                int row = (randomNumber % rows);
                if (row == 0 && randomNumber != 0)
                {
                    column--;
                    row = rows;
                }
                else
                {
                    row++;
                }
                playingField[column, row - 1] = '*';
            }

            return playingField;
        }

        private static void LocalAccount(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char result = Calculate(field, i, j);
                        field[i, j] = result;
                    }
                }
            }
        }

        private static char Calculate(char[,] field, int fieldColumns, int fieldRows)
        {
            int counter = 0;
            int row = field.GetLength(0);
            int column = field.GetLength(1);

            if (fieldColumns - 1 >= 0)
            {
                if (field[fieldColumns - 1, fieldRows] == '*')
                {
                    counter++;
                }
            }
            if (fieldColumns + 1 < row)
            {
                if (field[fieldColumns + 1, fieldRows] == '*')
                {
                    counter++;
                }
            }
            if (fieldRows - 1 >= 0)
            {
                if (field[fieldColumns, fieldRows - 1] == '*')
                {
                    counter++;
                }
            }
            if (fieldRows + 1 < column)
            {
                if (field[fieldColumns, fieldRows + 1] == '*')
                {
                    counter++;
                }
            }
            if ((fieldColumns - 1 >= 0) && (fieldRows - 1 >= 0))
            {
                if (field[fieldColumns - 1, fieldRows - 1] == '*')
                {
                    counter++;
                }
            }
            if ((fieldColumns - 1 >= 0) && (fieldRows + 1 < column))
            {
                if (field[fieldColumns - 1, fieldRows + 1] == '*')
                {
                    counter++;
                }
            }
            if ((fieldColumns + 1 < row) && (fieldRows - 1 >= 0))
            {
                if (field[fieldColumns + 1, fieldRows - 1] == '*')
                {
                    counter++;
                }
            }
            if ((fieldColumns + 1 < row) && (fieldRows + 1 < column))
            {
                if (field[fieldColumns + 1, fieldRows + 1] == '*')
                {
                    counter++;
                }
            }
            return char.Parse(counter.ToString());
        }
    }
}
