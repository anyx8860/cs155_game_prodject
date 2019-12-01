using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public enum Suits
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds
    }

    public enum Faces
    {
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
        Ace =14
    }

    class Card : IComparable
    {
        private Suits _suit;
        private Faces _face;

        public Suits Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Faces Face
        {
            get { return _face; }
            set { _face = value; }
        }

        public Card(Suits suit, Faces face)
        {
            Suit = suit;
            Face = face;
        }

        public override string ToString()
        {
            return Face + " of " + Suit;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
        
            Card otherCard = obj as Card;
            if (otherCard != null) 
                return this.Face.CompareTo(otherCard.Face);
            else
                throw new ArgumentException("Object is not a Temperature");
        }
    }
}
