using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This file will create the acceptable values for each card
namespace Go_Fish
{
    // Create enumeration for the Suits of the Cards
    enum Suits
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    // Create an enumeration for the FaceValue of the Cards
    enum FaceValue
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
        King = 13
    }

    class Card
    {
        // Create instance variables to allow getter/setters
        private Suits suitValue;
        private FaceValue cardFace;

        // Create getter and setter methods for each enum values
        // Getter
        public Suits getCardSuit()
        {
            return this.suitValue;
        }

        // setter
        public void setCardSuit(Suits suitIn)
        {
            this.suitValue = suitIn;
        }

        // Getter
        public FaceValue getCardFace()
        {
            return this.cardFace;
        }

        // setter
        public void setFaceValue(FaceValue valueIn)
        {
            this.cardFace = valueIn;
        }


        // Empty constructor
        public Card()
        {

        }

        // Full constructor
        public Card(Suits suitIn, FaceValue faceIn)
        {
            this.suitValue = suitIn;
            this.cardFace = faceIn;
        }

        // Copy constructor
        public Card(Card theObject)
        {
            this.suitValue = theObject.getCardSuit();
            this.cardFace = theObject.getCardFace();
        }

        // Equals methods
        public bool equals(Card obj)
        {
            if (this.suitValue == obj.getCardSuit() && this.cardFace == obj.getCardFace())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // To String method
        public string toString()
        {
            return string.Format("{0} of {1}", this.cardFace, this.suitValue);
        }
    }
}
