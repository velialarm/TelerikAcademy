using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Poker
{
    public class Hand : IHand
    {
        private const string Separator = " ";

        // TODO: Copy
        public IList<ICard> Cards { get; private set; } 

        public Hand(params ICard[] cards)
        {
            this.Cards = cards;
        }

        public static Hand Parse(string s)
        {
            Card[] cards = Regex.Split(s, Separator).Select(Card.Parse).ToArray();

            return new Hand(cards);
        }

        public static implicit operator Hand(String s)
        {
            return Hand.Parse(s);
        }

        public override string ToString()
        {
            return String.Join(Separator, this.Cards);
        }
    }
}
