using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGame
{
    enum MatchingCondition
    {
        cardValue = 1,
        cardSuit = 2,
        cardValueAndSuit = 3

    };
    class Program
    {
        private static MatchingCondition snapMatch;

        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Card cardDealed;
            Card lastCard = new Card();
            int rankPlayer1;
            int rankPlayer2;
            Player winner;
            bool draw = false;

            /****
             * Defining how many packs to use (i.e. define N )
             */

            Console.WriteLine("Hello Snap!");
            Console.WriteLine("Please indicate how many packs to use.\n");

            int numPacks = Convert.ToInt32(Console.ReadLine());
            List<Card> cardsPlayed = new List<Card>();

            /*
             * Defining the matching condition 
             */

            Console.WriteLine("Please define which of the three matching conditions to use: value - type 1, suit - type 2, both - type 3.");

            int mcNumber = Convert.ToInt32(Console.ReadLine());

            if (mcNumber > 0 && mcNumber < 4)
            {
                // cast to the enum value
                snapMatch = (MatchingCondition)mcNumber;

            }
            else 
            {
                Console.WriteLine("That number doesn't represent a matching condition.");
            }

            Console.WriteLine("Hit any key to start the game.");
            Console.ReadKey();

            // Starts the game

            Snap mySnap = new Snap(numPacks, snapMatch);

            mySnap.ShuffleAndStack();

            // to be done : play with numPacks > 1 and according a specific match condition.
         
            while (!mySnap.PileExhausted())
            {                               
                cardDealed = mySnap.DealCard();
                cardsPlayed.Add(cardDealed);
                if (lastCard == cardDealed)
                {
                    Random rngPlayer = new Random();
                    int player = rngPlayer.Next(1, 2);

                    if (player == 1)
                    {
                        mySnap.TakesOwnerShip(cardsPlayed, player1);
                        //player1.shoutSnap();
                    }
                    else
                    {
                        mySnap.TakesOwnerShip(cardsPlayed, player2);
                        //player2.shoutSnap();
                    }
                }
                lastCard = cardDealed;
            }

            // Tallying  up the total number of cards each player has accumulated

            rankPlayer1 = mySnap.TotalCards(player1);
            rankPlayer2 = mySnap.TotalCards(player2);

            if (rankPlayer1 > rankPlayer2)
            {
                winner = player1;
                Console.WriteLine($"The winner is {player1.Name}");
            }
            else if (rankPlayer1 < rankPlayer2)
            {
                winner = player2;
                Console.WriteLine($"The winner is {player2.Name}");
            }
            else {
                Console.WriteLine($"There was a draw");
            }
        }   
    }
}

