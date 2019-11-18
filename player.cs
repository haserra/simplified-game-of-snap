using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGame
{
    /// <summary>
    /// Each player owns his/ her pile of cards and in the end accumulates a certain number of cards
    /// </summary>
    class Player
    {
        int id;
        public string Name { get; set; }
        public List<Card> PileOfCard { get;  set; }
        public int Rank { get; set; }
        
    }
}
