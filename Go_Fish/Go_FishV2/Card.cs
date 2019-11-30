using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// This file will create the acceptable values for each card
namespace Go_Fish
{
    // Create enumeration for the Suits of the Cards
    public enum Suits
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    // Create an enumeration for the FaceValue of the Cards
    public enum FaceValue
    {
        ACE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        JACK = 11,
        QUEEN = 12,
        KING = 13
    }

    public class Card
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
        public Card(FaceValue faceIn)
        {
            this.cardFace = faceIn;
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