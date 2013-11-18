namespace JustBelot.Tests.GameLogicTest
{
    using System;

    using JustBelot.AI.DummyPlayer;
    using JustBelot.Common;
    using JustBelot.AI.AnnabelleBransfordAI;
    
    

    class Program
    {
        private static void Main()
        {
            IPlayer southPlayer = new AnnabelleBransfordAI("South dummy");
            IPlayer eastPlayer = new DummyPlayer("East dummy");
            IPlayer northPlayer = new AnnabelleBransfordAI("North dummy");
            IPlayer westPlayer = new DummyPlayer("West dummy");
            var game = new GameManager(southPlayer, eastPlayer, northPlayer, westPlayer);
            game.GameInfo.PlayerBid += GameInfoOnPlayerBid;
            game.GameInfo.CardPlayed += GameInfoOnCardPlayed;

            int testSouthNorth = 0;
            int testEastWest = 0;
            for (int j = 0; j < 25; j++)
            {
                testSouthNorth = 0;
                testEastWest = 0;
                for (int i = 0; i < 5000; i++)
                {
                    game.StartNewGame();
                    if (game.SouthNorthScore > game.EastWestScore)
                    {
                        testSouthNorth++;
                    }
                    else
                    {
                        testEastWest++;
                    }
                    //Console.WriteLine("{0} - {1}", game.SouthNorthScore, game.EastWestScore);
                }
                Console.WriteLine("Games won SN: {0} - Games won EW: {1}", testSouthNorth, testEastWest );
            }
        }

        private static void GameInfoOnPlayerBid(BidEventArgs eventArgs)
        {
            //Console.WriteLine("{1} from {0}", eventArgs.Position, eventArgs.Bid);
            ////Console.ReadKey();
        }

        private static void GameInfoOnCardPlayed(CardPlayedEventArgs eventArgs)
        {
            //Console.WriteLine("{0} played {1}", eventArgs.Position, eventArgs.PlayAction.Card);
            ////Console.ReadKey();
        }
    }
}
