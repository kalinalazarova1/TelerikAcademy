using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorHandNullCards()
        {
            IList<ICard> cards = null;
            var hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorHandZeroCards()
        {
            var cards = new List<ICard>();
            var hand = new Hand(cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorHandOneCard()
        {
            var cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            var hand = new Hand(cards);
        }

        [TestMethod]
        public void TestConstructorHandFiveCards()
        {
            var cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            Assert.AreEqual(hand.Cards, cards);
        }


        [TestMethod]
        public void TestHandToString()
        {
            var cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            Assert.AreEqual(hand.ToString(), "(♣2, ♣3, ♣4, ♣5, ♣6)");
        }
    }
}
