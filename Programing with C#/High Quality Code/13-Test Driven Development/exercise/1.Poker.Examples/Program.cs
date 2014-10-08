using System;

namespace Poker.Examples
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new Card(CardFace.Ace, CardSuit.Clubs));

            IPokerHandsChecker checker = new PokerHandsChecker();

        }
    }
}
