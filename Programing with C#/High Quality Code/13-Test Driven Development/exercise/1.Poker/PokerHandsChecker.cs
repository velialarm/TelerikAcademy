using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private void ValidExceptionHelper(IHand hand)
        {
            if (!IsValidHand(hand))
                throw new ArgumentException("Hand is not valid!");
        }

        private bool IsFaceRepeated(IHand hand, int times)
        {
            return hand.Cards
                .GroupBy(card => card.Face)
                .Select(group => group.Count())
                .Contains(times);
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
                throw new ArgumentNullException("hand");

            return hand.Cards.Distinct().Count() == 5;
        }

        public bool IsStraightFlush(IHand hand)
        {
            ValidExceptionHelper(hand);

            return IsFlush(hand) && IsStraight(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            ValidExceptionHelper(hand);

            return IsFaceRepeated(hand, 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            ValidExceptionHelper(hand);

            return IsOnePair(hand) && IsThreeOfAKind(hand); // TODO: Remove repeating
        }

        public bool IsFlush(IHand hand)
        {
            ValidExceptionHelper(hand);

            return hand.Cards.GroupBy(card => card.Suit).Count() == 1;
        }

        // TODO: Refactor
        public bool IsStraight(IHand hand)
        {
            ValidExceptionHelper(hand);

            var uniqueFaces = hand.Cards.Select(card => card.Face).Distinct();

            bool straight = ((uniqueFaces.Max() - uniqueFaces.Min()) == 4);

            if (!straight)
            {
                bool isHighestFive = (uniqueFaces.Take(4).Max() == CardFace.Five);
                bool isLowestAce = (uniqueFaces.Max() == CardFace.Ace);

                straight = isHighestFive && isLowestAce;
            }

            return straight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            ValidExceptionHelper(hand);

            return IsFaceRepeated(hand, 3);
        }

        public bool IsTwoPair(IHand hand)
        {
            ValidExceptionHelper(hand);

            var pairs = hand.Cards
                .GroupBy(card => card.Face)
                .Where(group => group.Count() == 2);

            return pairs.Count() == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            ValidExceptionHelper(hand);

            return IsFaceRepeated(hand, 2);
        }

        public bool IsHighCard(IHand hand)
        {
            ValidExceptionHelper(hand);

            return true;
        }

        public int CompareHands(IHand hand1, IHand hand2)
        {
            ValidExceptionHelper(hand1);
            ValidExceptionHelper(hand2);

            throw new NotImplementedException();
        }
    }
}
