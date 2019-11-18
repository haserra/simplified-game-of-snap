using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGame
{
    /// <summary>
    /// Standard card , 4 suits
    /// </summary>
    class Card
    {
        public Suit Suit { get; set;}
        public Value Value { get; set;}

    }

    public enum Suit
    {
        Hearts = 0,
        Diamonds = 1,
        Clubs = 2,
        Spades = 3
    }

    public enum Value
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
