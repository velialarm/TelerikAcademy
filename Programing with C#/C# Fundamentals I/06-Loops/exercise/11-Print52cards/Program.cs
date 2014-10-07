using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). The cards should be printed with their English names. Use nested for loops and switch-case.

            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
            string[] colors = { "Clubs", "Diamonds", "Hearts", "Spades" };
            foreach (var rank in ranks)
            {
                foreach (var color in colors)
                {
                    Console.WriteLine(rank +"  " + color);
                }
            }
        }
    }
