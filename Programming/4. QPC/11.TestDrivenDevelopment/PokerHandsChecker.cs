using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            return !(hand.Cards.GroupBy(x => x).Where(g => g.Count() > 1).Count() > 0); 
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isSameSuit = hand.Cards.GroupBy(x => x.Suit).Where(g => g.Count() ==  5).Count() > 0;
            var faces = hand.Cards.OrderBy(x => x.Face).Select(x => (uint)x.Face).ToArray();
            for (int i = 1; i < faces.Length; i++)
            {
                if (faces[i] != faces[i - 1] + 1)
                {
                    return false;
                }
            }

            return isSameSuit;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 4).Count() > 0;
        }

        public bool IsFullHouse(IHand hand)
        {
            return hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 3).Count() > 0 &&
                hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 2).Count() > 0;
        }

        public bool IsFlush(IHand hand)
        {
            if(this.IsStraightFlush(hand))
            {
                return false;
            }
            return hand.Cards.GroupBy(x => x.Suit).Where(g => g.Count() == 5).Count() > 0;
        }

        public bool IsStraight(IHand hand)
        {
            if(this.IsStraightFlush(hand))
            {
                return false;
            }
            var faces = hand.Cards.OrderBy(x => x.Face).Select(x => (uint)x.Face).ToArray();
            for (int i = 1; i < faces.Length; i++)
            {
                if (faces[i] != faces[i - 1] + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if(IsFullHouse(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 3).Count() > 0;
        }

        public bool IsTwoPair(IHand hand)
        {
            return hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 2).Count() == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (IsFullHouse(hand))
            {
                return false;
            }

            return hand.Cards.GroupBy(x => x.Face).Where(g => g.Count() == 2).Count() == 1;
        }

        public bool IsHighCard(IHand hand)
        {
            return !(this.IsFlush(hand) ||
                this.IsFourOfAKind(hand) ||
                this.IsFullHouse(hand) ||
                this.IsOnePair(hand) ||
                this.IsStraight(hand) ||
                this.IsStraightFlush(hand) ||
                this.IsThreeOfAKind(hand) ||
                this.IsTwoPair(hand)) && this.IsValidHand(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstStrength = GetHandStrength(firstHand);
            int secondStrength = GetHandStrength(secondHand);
            if(firstStrength != secondStrength)
            {
                return firstStrength.CompareTo(secondStrength);
            }

            switch (firstStrength)
            {
                case 9:     // Straight Flush
                    return CompareStraights(firstHand.Cards, secondHand.Cards);
                case 8:     // Four Of A Kind
                    return ((uint)firstHand.Cards[0].Face).CompareTo((uint)secondHand.Cards[0].Face);
                case 7:     // Full House
                    if(firstHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 3).Select(g => (uint)g.Key).ElementAt(0) !=
                        secondHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 3).Select(g => (uint)g.Key).ElementAt(0))
                    {
                        return firstHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 3).Select(g => (uint)g.Key).ElementAt(0).CompareTo(
                            secondHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 3).Select(g => (uint)g.Key).ElementAt(0));
                    }

                    return firstHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0).CompareTo(
                            secondHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0));
                case 6:     // Flush
                    return CompareHighCards(firstHand.Cards, secondHand.Cards);
                case 5:     // Straight
                    return CompareStraights(firstHand.Cards, secondHand.Cards);
                case 4:     // Three of A Kind
                    return CompareMaxFace(firstHand.Cards, secondHand.Cards);
                case 3:     // Two Pairs
                    var firstFaces = firstHand.Cards.GroupBy(c => c.Face).OrderBy(g => (uint)g.Key).Select(g => (uint)g.Key);
                    var secondFaces = secondHand.Cards.GroupBy(c => c.Face).OrderBy(g => (uint)g.Key).Select(g => (uint)g.Key);
                    for (int i = 0; i < 3; i++)
                    {
                        if(firstFaces.ElementAt(i) != secondFaces.ElementAt(i))
                        {
                            return firstFaces.ElementAt(i).CompareTo(secondFaces.ElementAt(i));
                        }
                    }

                    return 0;
                case 2:     // One Pair
                    if(firstHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0) !=
                        secondHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0))
                    {
                        return firstHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0).CompareTo(
                        secondHand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == 2).Select(g => (uint)g.Key).ElementAt(0));
                    }

                    return CompareHighCards(firstHand.Cards.Except(secondHand.Cards).ToList(), secondHand.Cards.Except(firstHand.Cards).ToList());
                default:     // High Card
                    return CompareHighCards(firstHand.Cards, secondHand.Cards);
            }
        }

        private int GetHandStrength(IHand hand)
        {
            if (IsStraightFlush(hand))
            {
                return 9;
            }

            if (IsFourOfAKind(hand))
            {
                return 8;
            }

            if (IsFullHouse(hand))
            {
                return 7;
            }

            if (IsFlush(hand))
            {
                return 6;
            }

            if (IsStraight(hand))
            {
                return 5;
            }

            if (IsThreeOfAKind(hand))
            {
                return 4;
            }

            if (IsTwoPair(hand))
            {
                return 3;
            }

            if(IsOnePair(hand))
            {
                return 2;
            }

            return 1;
        }

        private int CompareStraights(IList<ICard> firstCards, IList<ICard> secondCards)
        {
            return firstCards.Max(c => (uint)c.Face).CompareTo(secondCards.Max(c => (uint)c.Face));
        }

        private int CompareHighCards(IList<ICard> firstCards, IList<ICard> secondCards)
        {
            var first = firstCards.OrderByDescending(c => (uint)c.Face).Select(c => (uint)c.Face).ToArray();
            var second = secondCards.OrderByDescending(c => (uint)c.Face).Select(c => (uint)c.Face).ToArray();
            if (!first.SequenceEqual(second))
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] > second[i])
                    {
                        return 1;
                    }
                    else if (second[i] > first[i])
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }

        private int CompareMaxFace(IList<ICard> firstCards, IList<ICard> secondCards)
        {
            return firstCards.Max(c => (uint)c.Face).CompareTo(secondCards.Max(c => (uint)c.Face));
        }
    }
}
