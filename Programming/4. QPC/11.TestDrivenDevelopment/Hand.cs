using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Hand : IHand
    {
        private const int CardsCount = 5;
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if(cards == null)
            {
                throw new ArgumentNullException("The cards in the hand could not be null!");
            }

            if(cards.Count != Hand.CardsCount)
            {
                throw new ArgumentException("The cards count in the hand have to be " + Hand.CardsCount + "!");
            }

            this.Cards = cards;
        }

        public override string ToString()
        {
            return "(" + string.Join(", ", this.Cards) + ")";
        }
    }
}
