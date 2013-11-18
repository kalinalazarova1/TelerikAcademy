using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBelot.Common;
using JustBelot.Common.Extensions;

namespace JustBelot.AI.AnnabelleBransfordAI
{
    internal enum ContractStrength
    {
        Strong = 0, Normal = 1, Weak = 2, Special = 3
    }

    public class AnnabelleBransfordAI : IPlayer
    {
        private List<BidType> partnerBids;
        private List<BidType> otherBids;
        private List<BidType> allBids;
        private List<Card> remainedInGame;
        private List<Card> onTheTable;

        private readonly Hand hand = new Hand();

        public AnnabelleBransfordAI()
        {
            this.Name = "AnnabelleAI player";
            this.partnerBids = new List<BidType>();
            this.otherBids = new List<BidType>();
            this.allBids = new List<BidType>();
            this.remainedInGame = new List<Card>();
            this.onTheTable = new List<Card>();
            this.myPartnerBurst = null;
        }

        public AnnabelleBransfordAI(string name) : this()
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        private GameInfo Game { get; set; }

        private PlayerPosition Position { get; set; }

        private PlayerPosition startsFirst;

        private CardSuit? myPartnerBurst;

        private ContractType currentContract
        {
            get
            {
                int i;
                for (i = allBids.Count - 1; allBids[i] == BidType.ReDouble || allBids[i] == BidType.Double || allBids[i] == BidType.Pass; i--) ;
                return (ContractType)allBids[i];
            }
        }

        private PlayerPosition MyPartnerPosition
        {
            get
            {
                return (PlayerPosition)(((int)this.Position + 2) % 4);
            }
        }

        private void AddBid(BidEventArgs eventArgs)
        {
            if (this.allBids.Count == 0)
            {
                this.startsFirst = eventArgs.Position;
            }
            if (eventArgs.Position == this.MyPartnerPosition && eventArgs.Bid != BidType.Pass)
            {
                this.partnerBids.Add(eventArgs.Bid);
            }
            else if (!this.Position.Equals(eventArgs.Position) && eventArgs.Bid != BidType.Pass)
            {
                this.otherBids.Add(eventArgs.Bid);
            }
            this.allBids.Add(eventArgs.Bid);
        }

        private void AddCardPlayed(CardPlayedEventArgs eventArgs)
        {
            if (eventArgs.Position != this.Position)
            {
                this.remainedInGame.Remove(eventArgs.PlayAction.Card);
            }
            this.onTheTable.Add(eventArgs.PlayAction.Card);
            if (this.onTheTable.Count == 4)
            {
                if (this.myPartnerBurst == null && this.startsFirst == this.MyPartnerPosition && onTheTable.ElementAt(0).GetValue(this.currentContract) < onTheTable.Max().GetValue(this.currentContract))
                {
                    this.myPartnerBurst = onTheTable.ElementAt(0).Suit;
                }
                this.onTheTable.Clear();
            }
        }

        public void StartNewGame(GameInfo gameInfo, PlayerPosition position)
        {
            this.Position = position;
            this.Game = gameInfo;
            this.otherBids.Clear();
            this.partnerBids.Clear();
            this.allBids.Clear();
            this.remainedInGame = CardsCollection.FullDeckOfCards.ToList();
            this.Game.CardPlayed += this.AddCardPlayed;
            this.Game.PlayerBid += this.AddBid;
            this.myPartnerBurst = null;
        }

        public void StartNewDeal(DealInfo dealInfo)
        {
            this.hand.Clear();
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                this.hand.Add(card);
                this.remainedInGame.Remove(card);
            }
        }

        public BidType AskForBid(Contract currentContract, IList<BidType> allowedBids, IList<BidType> previousBids)
        {
            if (this.SpecialAssessor() && this.partnerBids.Count == 0 && this.otherBids.Count == 0)
            {
                if (allowedBids.Count > 1
                    && allowedBids.OrderBy(x => (int)x).ElementAt(1) != BidType.NoTrumps
                    && allowedBids.OrderBy(x => (int)x).ElementAt(1) != BidType.AllTrumps)
                {
                    return allowedBids.OrderBy(x => (int)x).ElementAt(1);
                }
            }
            if (ContractAssesor(currentContract.Type) == ContractStrength.Strong
                && currentContract.OriginalBidder != this.Position
                && currentContract.OriginalBidder != this.MyPartnerPosition
                && !currentContract.IsDoubled
                && !currentContract.IsReDoubled)
            {
                return BidType.Double;
            }
            if (ContractAssesor(currentContract.Type) == ContractStrength.Strong
                && currentContract.OriginalBidder == this.Position
                && currentContract.OriginalBidder == this.MyPartnerPosition
                && currentContract.IsDoubled
                && !currentContract.IsReDoubled)
            {
                return BidType.ReDouble;
            }
            foreach (BidType bid in allowedBids.OrderByDescending(x => (int)x))
            {
                if (!bid.Equals(BidType.Pass)
                    && !bid.Equals(BidType.Double)
                    && !bid.Equals(BidType.ReDouble)
                    && this.ContractAssesor((ContractType)bid) == ContractStrength.Strong)
                {
                    return bid;
                }
            }
            if (currentContract.OriginalBidder == this.MyPartnerPosition || ContractAssesor(currentContract.Type) == ContractStrength.Normal)
            {
                return BidType.Pass;
            }
            else
            {
                foreach (BidType bid in allowedBids.OrderBy(x => (int)x))
                {
                    if (!bid.Equals(BidType.Pass)
                        && !bid.Equals(BidType.Double)
                        && !bid.Equals(BidType.ReDouble)
                        && this.ContractAssesor((ContractType)bid) == ContractStrength.Normal)
                    {
                        return bid;
                    }
                }
                return BidType.Pass;
            }
        }

        public IEnumerable<CardsCombination> AskForCardsCombinations(IEnumerable<CardsCombination> allowedCombinations)
        {
            return allowedCombinations;             
        }

        public PlayAction PlayCard(IList<Card> allowedCards, IList<Card> currentTrickCards)
        {
            Card cardToPlay = new List<Card>(allowedCards).RandomElement();
            if (this.startsFirst != this.Position)
            {
                if (this.WinningThinnerTactic(ref cardToPlay, allowedCards, currentTrickCards))
                {
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
                else
                {
                    this.ThinnerTactic(ref cardToPlay, allowedCards, currentTrickCards);
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
            }
            else
            {
                if ((this.hand.Count <= 5 || this.currentContract.IsTrump()) && this.RussianTzarTactic(ref cardToPlay, allowedCards, currentTrickCards))
                {
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
                else if (this.PartnerSeekingTactic(ref cardToPlay, allowedCards, currentTrickCards))
                {
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
                else if (this.CardBursterTactic(ref cardToPlay, allowedCards, currentTrickCards))
                {
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
                else
                {
                    this.ThinnerTactic(ref cardToPlay, allowedCards, currentTrickCards);
                    this.hand.Remove(cardToPlay);
                    return new PlayAction { Card = cardToPlay, AnnounceBeloteIfAvailable = true };
                }
            }
        }

        public void EndOfDeal(DealResult dealResult)
        {
        }

        private ContractStrength ContractAssesor(ContractType contract)
        {
            switch (contract)
            {
                case ContractType.Clubs:
                    return TrumpsAssessor(ContractType.Clubs);
                case ContractType.Diamonds:
                    return TrumpsAssessor(ContractType.Diamonds);
                case ContractType.Hearts:
                    return TrumpsAssessor(ContractType.Hearts);
                case ContractType.Spades:
                    return TrumpsAssessor(ContractType.Spades);
                case ContractType.NoTrumps:
                    return NoTrumpsAssessor();
                case ContractType.AllTrumps:
                    return AllTrumpsAssessor();
                default:
                    return ContractStrength.Weak;
            }
        }

        private bool SpecialAssessor()
        {
            int[] types = new int[8];
            foreach (var card in this.hand)
            {
                if (card.Type == CardType.Nine || card.Type == CardType.Ten || card.Type == CardType.Queen || card.Type == CardType.King)
                {
                    types[(int)card.Type]++;
                }
            }
            return types.Contains(4);
        }

        private ContractStrength TrumpsAssessor(ContractType trumps)
        {
            ContractStrength result = ContractStrength.Weak;
            int strength = 0;
            CardSuit trumpsSuit = (CardSuit)((int)trumps - 1);
            int trumpCount = this.hand.Count(x => x.Suit == trumpsSuit);
            strength += (trumpCount - 2) * 2;
            foreach (var card in this.hand)
            {
                if (card.Suit == trumpsSuit && card.Type == CardType.Jack)
                {
                    strength += 3;
                }
                else if (card.Suit == trumpsSuit && card.Type == CardType.Nine && trumpCount > 1)
                {
                    strength += 2;
                }
                else if (card.Suit != trumpsSuit && card.Type == CardType.Ace)
                {
                    strength += 2;
                }
                else if (card.Suit != trumpsSuit && card.Type == CardType.Ten && this.hand.Count(x => x.Suit == card.Suit) > 1)
                {
                    strength += 1;
                }   
            }
            if (strength >= 7)
            {
                result = ContractStrength.Strong;
            }
            else if (strength >= 6)
            {
                result = ContractStrength.Normal;
            }
            return result;
        }

        private ContractStrength NoTrumpsAssessor()
        {
            ContractStrength result = ContractStrength.Weak;
            int strength = 0;
            int[] suits = new int[4];
            foreach (var card in this.hand)
            {
                suits[(int)card.Suit]++;
            }
            if ((suits.Count(x => x > 0) == 1))
            {
                strength--;
            }
            foreach (var card in this.hand)
            {
                if (card.Type == CardType.Ace)
                {
                    strength += 3;
                    if (suits[(int)card.Suit] > 2)
                    {
                        strength++;
                    }
                }
                else if (card.Type == CardType.Ten && suits[(int)card.Suit] > 1)
                {
                    strength += 2;
                }
            }
            if (strength >= 8)
            {
                result = ContractStrength.Strong;
            }
            else if (strength >= 6)
            {
                result = ContractStrength.Normal;
            }
            return result;
        }

        private ContractStrength AllTrumpsAssessor()
        {
            ContractStrength result = ContractStrength.Weak;
            int strength = 0;
            int[] suits = new int[4];
            foreach (var card in this.hand)
            {
                suits[(int)card.Suit]++;
            }
            if((suits.Count(x => x > 0) == 1))
            {
                strength--;
            }
            foreach (var card in this.hand)
            {
                if (card.Type == CardType.Jack)
                {
                    strength += 3;
                    if (suits[(int)card.Suit] > 2)
                    {
                        strength++;
                    }
                }
                else if (card.Type == CardType.Nine && suits[(int)card.Suit] > 1)
                {
                    strength += 2;
                }
            }
            if (strength >= 8)
            {
                result = ContractStrength.Strong;
            }
            else if (strength >= 6)
            {
                result = ContractStrength.Normal;
            }
            return result;
        }

        private bool RussianTzarTactic(ref Card cardToPlay, IList<Card> allowedCards, IList<Card> currentTrickCards)    //used only when starts first
        {
            foreach (Card card in allowedCards.OrderByDescending(x => x.GetValue(this.currentContract)))
            {
                bool isWinner = true;
                foreach (Card item in this.remainedInGame.Where(x => x.Suit == card.Suit))
                {
                    if (card.Type < item.Type)
                    {
                        isWinner = false;
                        break;   
                    }
                }
                if (isWinner)
                {
                    cardToPlay = card;
                    return true;
                }
            }
            return false;
        }

        private bool WinningThinnerTactic(ref Card cardToPlay, IList<Card> allowedCards, IList<Card> currentTrickCards)     //only when playes last
        {
            foreach (Card card in allowedCards.OrderBy(x => x.GetValue(this.currentContract)))
            {
                bool isWinner = true;
                foreach (Card item in this.onTheTable.Where(x => x.Suit == card.Suit))
                {
                    if (card.Type < item.Type)
                    {
                        isWinner = false;
                        break;
                    }
                }
                if (isWinner)
                {
                    cardToPlay = card;
                    return true;
                }
            }
            return false;
        }

        private bool CardBursterTactic(ref Card cardToPlay, IList<Card> allowedCards, IList<Card> currentTrickCards)    //used only when starts first, could be further improved
        {
            foreach (Card card in allowedCards.OrderByDescending(x => x.GetValue(this.currentContract)))
            {
                foreach (Card item in this.remainedInGame.Where(x => x.Suit == card.Suit))
                {
                    if (card.Type < item.Type)
                    {
                        if (allowedCards.Count(x => x.Suit == card.Suit) > 1)
                        {
                            cardToPlay = allowedCards.Where(x => x.Suit == card.Suit).OrderByDescending(x => x.GetValue(this.currentContract)).ElementAt(1);
                            return true;
                        }
                        break;
                    }
                }
            }
            return false;
        }

        private bool ThinnerTactic(ref Card cardToPlay, IList<Card> allowedCards, IList<Card> currentTrickCards)
        {
            cardToPlay = allowedCards.OrderBy(x => x.GetValue(this.currentContract)).ElementAt(0);
            return true;
        }

        private bool PartnerSeekingTactic(ref Card cardToPlay, IList<Card> allowedCards, IList<Card> currentTrickCards)     //used only when starts first
        {
            CardSuit? myPartnerSuit = null;
            if (this.partnerBids.Count(x => x != BidType.AllTrumps || x != BidType.NoTrumps || x != BidType.Double || x != BidType.ReDouble) > 0)
            {
                myPartnerSuit = (CardSuit)((this.partnerBids.Where(x => x != BidType.AllTrumps || x != BidType.NoTrumps || x != BidType.Double || x != BidType.ReDouble).ElementAt(0)) - 1);
            }
            if (myPartnerSuit != null && allowedCards.Any(x => x.Suit == myPartnerSuit))
            {
                cardToPlay = allowedCards.Where(x => x.Suit == myPartnerSuit).OrderByDescending(x => x.GetValue(this.currentContract)).ElementAt(0);
                return true;
            }
            if (this.myPartnerBurst != null && allowedCards.Any(x => x.Suit == this.myPartnerBurst))
            {
                cardToPlay = allowedCards.Where(x => x.Suit == this.myPartnerBurst).OrderByDescending(x => x.GetValue(this.currentContract)).ElementAt(0);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
