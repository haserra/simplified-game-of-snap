using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGame
{
    /// <summary>
    /// Simplified Snap! game : creates the pack of cards (I'm only using 1 pack), shuffles and stacks , deals, and simulates a match 
    /// 
    /// </summary>
    class Snap
    {
 
        private Card[] pack;
        private Stack<Card> pile;

        public Snap(int nPacks, MatchingCondition snapCond)
        {           
            pack = new Card[]
            {
                new Card(){Suit = 0, Value = 1},
                new Card(){Suit = 1, Value = 2},
                new Card(){Suit = 2, Value = 3},
                new Card(){Suit = 3, Value = 4},
                new Card(){Suit = 0, Value = 5},
                new Card(){Suit = 0, Value = 6},
                new Card(){Suit = 0, Value = 7},
                new Card(){Suit = 0, Value = 8},
                // etc until the 52 cards are created
            };

        }

        public void ShuffleAndStack()
        {
            Random rng = new Random();
            int n = pack.Length;
            int k;
            // shuffle the pack of cards
            while (n > 1)
            {
                n--;
                k = rng.Next(n + 1);
                Card value = pack[k];
                pack[k] = pack[n];
                pack[n] = value;
            }
            // and stacks them
            foreach (Card card in pack)
            {
                pile.Push(card);
            }
        }

        public Card DealCard()
        {
            Card cardPlayed = pile.Pop();
            return cardPlayed;
        }

        public bool PileExhausted()
        {
            return (pile.Count > 0) ? false : true;
        }

        public void TakesOwnerShip(List<Card> cards, Player player)
        {
            foreach (Card card in cards)
            {
                player.PileOfCard.Add(card);
            }            
        }

        public int TotalCards(Player player) 
        {
            player.Rank = player.PileOfCard.Count;

            return player.Rank;
        }
    }
}
