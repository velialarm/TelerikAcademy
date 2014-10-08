using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNull()
        {
            new PokerHandsChecker().IsValidHand(null);
        }

        [TestMethod]
        public void TestWithLessNumberOfCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            );

            bool actual = new PokerHandsChecker().IsValidHand(hand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestWithMoreNumberOfCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            );

            bool actual = new PokerHandsChecker().IsValidHand(hand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestWithDuplicateCards()
        {
            Hand hand = new Hand(
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            );

            bool actual = new PokerHandsChecker().IsValidHand(hand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestStraightFlush()
        {
            Hand hand = "J♣ 10♣ 9♣ 8♣ 7♣";

            bool actual = new PokerHandsChecker().IsStraightFlush(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            Hand hand = "4♣ 4♦ 4♥ 4♠ A♠";

            bool actual = new PokerHandsChecker().IsFourOfAKind(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestFullHouse()
        {
            Hand hand = "5♠ 5♥ 5♦ 8♠ 8♥";

            bool actual = new PokerHandsChecker().IsFullHouse(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestFlush()
        {
            Hand hand = "A♠ J♠ 10♠ 6♠ 3♠";

            bool actual = new PokerHandsChecker().IsFlush(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestStraight()
        {
            Hand hand = "9♠ 8♦ 7♠ 6♥ 5♠";

            bool actual = new PokerHandsChecker().IsStraight(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestStraightWheelValid()
        {
            Hand hand = "5♠ 4♦ 3♦ 2♠ A♥";

            bool actual = new PokerHandsChecker().IsStraight(hand);

            Assert.AreEqual(true, actual);
        }

        // Regression test
        [TestMethod]
        public void TestStraightWheelInvalid()
        {
            Hand hand = "5♠ 4♦ 3♦ 2♠ Q♥";

            bool actual = new PokerHandsChecker().IsStraight(hand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestStraightAceWrapAround()
        {
            Hand hand = "3♠ 2♦ A♥ K♠ Q♠";

            bool actual = new PokerHandsChecker().IsStraight(hand);

            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            Hand hand = "3♣ 3♦ 3♥ Q♠ 2♠";

            bool actual = new PokerHandsChecker().IsThreeOfAKind(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestTwoPair()
        {
            Hand hand = "K♣ K♠ 9♥ 9♦ J♥";

            bool actual = new PokerHandsChecker().IsTwoPair(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestOnePair()
        {
            Hand hand = "2♦ 2♥ Q♥ 7♥ 6♣";

            bool actual = new PokerHandsChecker().IsOnePair(hand);

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void TestHighCard()
        {
            Hand hand = "A♥ K♥ Q♣ 10♥ 2♣";

            bool actual = new PokerHandsChecker().IsHighCard(hand);

            Assert.AreEqual(true, actual);
        }
    }
}
