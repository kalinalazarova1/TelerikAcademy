namespace Poker
{
    using System;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var result = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    result = "♣";  
                    break;
                case CardSuit.Diamonds:
                    result = "♦";
                    break;
                case CardSuit.Hearts:
                    result = "♥";
                    break;
                case CardSuit.Spades:
                    result = "♠";
                    break;
            }
            switch (this.Face)
            {
                case CardFace.Two:
                    result += "2";
                    break;
                case CardFace.Three:
                    result += "3";
                    break;
                case CardFace.Four:
                    result += "4";
                    break;
                case CardFace.Five:
                    result += "5";
                    break;
                case CardFace.Six:
                    result += "6";
                    break;
                case CardFace.Seven:
                    result += "7";
                    break;
                case CardFace.Eight:
                    result += "8";
                    break;
                case CardFace.Nine:
                    result += "9";
                    break;
                case CardFace.Ten:
                    result += "10";
                    break;
                case CardFace.Jack:
                    result += "J";
                    break;
                case CardFace.Queen:
                    result += "Q";
                    break;
                case CardFace.King:
                    result += "K";
                    break;
                case CardFace.Ace:
                    result += "A";
                    break;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Card;
            if(obj == null)
            {
                throw new ArgumentException("The object for comparison should be card and not equal to null!");
            }

            return this.Suit == other.Suit && this.Face == other.Face;
        }

        public override int GetHashCode()
        {
            return this.Face.GetHashCode() ^ this.Suit.GetHashCode();
        }
    }
}
