using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTest
    {
        private void TestToString(string cardStr)
        {
            Card card = cardStr;

            Assert.AreEqual(cardStr, card.ToString());
        }

        [TestMethod]
        public void TestTwoToString()
        {
            TestToString("2♣");
        }

        [TestMethod]
        public void TestTenToString()
        {
            TestToString("10♣");
        }

        [TestMethod]
        public void TestAceToString()
        {
            TestToString("A♣");
        }

        [TestMethod]
        public void TestClubsToString()
        {
            TestToString("2♣");
        }

        [TestMethod]
        public void TestDiamondsToString()
        {
            TestToString("2♦");
        }

        [TestMethod]
        public void TestHeartsToString()
        {
            TestToString("2♥");
        }

        [TestMethod]
        public void TestSpadesToString()
        {
            TestToString("2♠");
        }
    }
}
