using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Card : ICard, IComparable<Card>
    {
        private static readonly Dictionary<string, CardFace> faceEnums = faceStrings.ToDictionary(x => x.Value, x => x.Key);
        private static readonly Dictionary<CardFace, string> faceStrings = new Dictionary<CardFace, string>()
        {
            { CardFace.Two,   "2"  },
            { CardFace.Three, "3"  },
            { CardFace.Four,  "4"  },
            { CardFace.Five,  "5"  },
            { CardFace.Six,   "6"  },
            { CardFace.Seven, "7"  },
            { CardFace.Eight, "8"  },
            { CardFace.Nine,  "9"  },
            { CardFace.Ten,   "10" },
            { CardFace.Jack,  "J"  },
            { CardFace.Queen, "Q"  },
            { CardFace.King,  "K"  },
            { CardFace.Ace,   "A"  },
        };

        private static readonly Dictionary<string, CardSuit> suitEnums = suitStrings.ToDictionary(x => x.Value, x => x.Key);
        private static readonly Dictionary<CardSuit, string> suitStrings = new Dictionary<CardSuit, string>()
        {
            { CardSuit.Clubs,    "♣" },
            { CardSuit.Diamonds, "♦" },
            { CardSuit.Hearts,   "♥" },
            { CardSuit.Spades,   "♠" }
        };

        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public static Card Parse(string s)
        {
            string faceStr = s.Substring(0, s.Length - 1);
            CardFace face = faceEnums[faceStr];

            string suitStr = s.Substring(s.Length - 1);
            CardSuit suit = suitEnums[suitStr];

            Card card = new Card(face, suit);

            return card;
        }

        public static implicit operator Card(String s)
        {
            return Card.Parse(s);
        }

        public override bool Equals(object obj)
        {
            Card otherCard = obj as Card;

            if (otherCard == null)
                return false;

            return
                this.Face == otherCard.Face &&
                this.Suit == otherCard.Suit
            ;
        }

        private static readonly int numberOfSuits = Enum.GetNames(typeof(CardSuit)).Length;
        public override int GetHashCode()
        {
            return ((int)this.Face * numberOfSuits) + (int)this.Suit;
        }

        public int CompareTo(Card other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return faceStrings[this.Face] + suitStrings[this.Suit];
        }
    }
}
