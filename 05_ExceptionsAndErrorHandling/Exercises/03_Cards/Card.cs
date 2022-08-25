using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
    public class Card
    {
        private readonly string[] validFaces = 
            { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private readonly IDictionary<string, string> validSuits
            = new Dictionary<string, string>()
            { {"S", "\u2660" }, {"H", "\u2665" }, {"D", "\u2666" }, {"C", "\u2663" } };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face 
        {
            get
            {
                return this.face;
            }
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }

        public string Suit
        {
            get
            {
                return this.suit;
            }
            private set
            {
                if (!validSuits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = validSuits[value];
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
