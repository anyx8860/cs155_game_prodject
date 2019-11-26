using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class that will create the deck of playing cards
namespace Go_Fish
{
    class Deck
    {
        // Create a random number generator 
        private Random random = new Random();


        // Create a List, because the size will constantly
        // be changing as we take cards in and out
        private List<Card> cardDeck;


        // Populate the Deck of Cards using the Card defined 
        // in Card.cs

        public Deck()
        {
            cardDeck = new List<Card>();
            for (int suitValue = 0; suitValue <= 3; suitValue++)
            {
                for (int cardFace = 1; cardFace <= 13; cardFace++)
                {
                    cardDeck.Add(new Card((Suits)suitValue, (FaceValue)cardFace));
                }
            }
        }

        // Method to print out the Card Deck?
        public List<Card> getCardDeck()
        {
            return this.cardDeck;
        }

        // Get method to know how many elements are in 
        // the list - NEED TO CHANGE
        public int getCount()
        {
            return this.cardDeck.Count;
        }

        int index = 0;

        private List<Card> PlayerHand;

        public List<Card> getPlayerHand()
        {

            PlayerHand = new List<Card>();
            for (index = 0; index < 7; index++)
            {
                int cardPull = random.Next(cardDeck.Count);
                PlayerHand.Add(cardDeck[cardPull]);
                cardDeck.Remove(cardDeck[cardPull]);
            }
            return this.PlayerHand;

        }



        // Need an Equals method


        // Need a toString method






    }
}
