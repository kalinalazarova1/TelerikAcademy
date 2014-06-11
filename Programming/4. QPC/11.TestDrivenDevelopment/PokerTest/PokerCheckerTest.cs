using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class PokerCheckerTest
    {
        [TestMethod]
        public void TestPokerCheckerValidHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPokerCheckerInvalidHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestPokerCheckerFlushHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotFlushHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotFlushButStraightFlushHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestPokerCheckerStraightFlushHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotStraightFlushHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestPokerCheckerFourOfKindHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotFourOfKindHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestPokerCheckerFullHouseHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotFullHouseHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestPokerCheckerTwoPairHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotTwoPairHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestPokerCheckerStraightHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotStraightHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotStraightButFlushStraightHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestPokerCheckerThreeOfAKindHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotThreeOfAKindHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestPokerCheckerOnePairHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotOnePairHandFullHouse()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotOnePairHandTwoPairs()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestPokerCheckerHighCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestPokerCheckerNotHighCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var hand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestPokerCheckerCompareDifferentHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoStraightFlushedHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoFourOfAKindHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoFullHouseHandsEqualHouses()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoFullHouseHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoFlushHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoStraightHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoThreeOfAKindHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoPairHandsFirstPairEqual()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoPairHandsFirstPairDifferent()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareTwoPairHandsEqualFaces()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 0);
        }

        [TestMethod]
        public void TestPokerCheckerCompareOnePairEqualFacesHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareOnePairDifferentFacesHands()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareHighCardHandsEqual()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 0);
        }

        [TestMethod]
        public void TestPokerCheckerCompareHighCardHandsFirstHigher()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }

        [TestMethod]
        public void TestPokerCheckerCompareHighCardHandsSecondHigher()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            var firstHand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            var secondHand = new Hand(cards);
            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }
    }
}
