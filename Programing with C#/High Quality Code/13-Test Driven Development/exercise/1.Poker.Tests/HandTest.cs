using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTest
    {
        private void TestToString(string handStr)
        {
            Hand hand = handStr;

            Assert.AreEqual(handStr, hand.ToString());
        }

        [TestMethod]
        public void TestToString1()
        {
            TestToString("A♣ A♦ K♥ K♠ 7♦");
        }

        [TestMethod]
        public void TestToString2()
        {
            TestToString("A♣ 2♦ 10♥ K♠ 7♦");
        }
    }
}
