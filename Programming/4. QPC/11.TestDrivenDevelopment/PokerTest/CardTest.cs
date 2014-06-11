using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestConstructorCardSuit()
        {
            var face = CardFace.Ace;
            var suit = CardSuit.Spades;
            Assert.AreEqual(new Card(face, suit).Suit, CardSuit.Spades);
        }

        [TestMethod]
        public void TestConstructorCardFace()
        {
            var face = CardFace.Ace;
            var suit = CardSuit.Spades;
            Assert.AreEqual(new Card(face, suit).Face, CardFace.Ace);
        }

        [TestMethod]
        public void TestCardAceSpadesToString()
        {
            var face = CardFace.Ace;
            var suit = CardSuit.Spades;
            Assert.AreEqual(new Card(face, suit).ToString(), "♠A");
        }

        [TestMethod]
        public void TestCardKingHeartsToString()
        {
            var face = CardFace.King;
            var suit = CardSuit.Hearts;
            Assert.AreEqual(new Card(face, suit).ToString(), "♥K");
        }

        [TestMethod]
        public void TestCardQueenDimondsToString()
        {
            var face = CardFace.Queen;
            var suit = CardSuit.Diamonds;
            Assert.AreEqual(new Card(face, suit).ToString(), "♦Q");
        }

        [TestMethod]
        public void TestCardJackClubsToString()
        {
            var face = CardFace.Jack;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣J");
        }

        [TestMethod]
        public void TestCardTenClubsToString()
        {
            var face = CardFace.Ten;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣10");
        }

        [TestMethod]
        public void TestCardNineClubsToString()
        {
            var face = CardFace.Nine;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣9");
        }

        [TestMethod]
        public void TestCardEightClubsToString()
        {
            var face = CardFace.Eight;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣8");
        }

        [TestMethod]
        public void TestCardSevenClubsToString()
        {
            var face = CardFace.Seven;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣7");
        }

        [TestMethod]
        public void TestCardSixClubsToString()
        {
            var face = CardFace.Six;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣6");
        }

        [TestMethod]
        public void TestCardFiveClubsToString()
        {
            var face = CardFace.Five;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣5");
        }

        [TestMethod]
        public void TestCardFourClubsToString()
        {
            var face = CardFace.Four;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣4");
        }

        [TestMethod]
        public void TestCardThreeClubsToString()
        {
            var face = CardFace.Three;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣3");
        }

        [TestMethod]
        public void TestCardTwoClubsToString()
        {
            var face = CardFace.Two;
            var suit = CardSuit.Clubs;
            Assert.AreEqual(new Card(face, suit).ToString(), "♣2");
        }

        [TestMethod]
        public void TestCardEqualsSameCard()
        {
            var face = CardFace.Two;
            var suit = CardSuit.Clubs;
            Assert.IsTrue(new Card(face, suit).Equals(new Card(face, suit)));
        }

        [TestMethod]
        public void TestCardEqualsDifferentCard()
        {
            var face = CardFace.Two;
            var suit = CardSuit.Clubs;
            var faceOther = CardFace.Two;
            var suitOther = CardSuit.Diamonds;
            Assert.IsFalse(new Card(face, suit).Equals(new Card(faceOther, suitOther)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCardEqualsNull()
        {
            var face = CardFace.Two;
            var suit = CardSuit.Clubs;
            var isFalse = new Card(face, suit).Equals(null);
        }
    }
}
