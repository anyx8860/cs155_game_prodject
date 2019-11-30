using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class that will create the deck of playing cards
namespace Go_Fish
{
    public class Deck
    {
        // Create a random number generator 
        private Random random = new Random();


        // Create a List, because the size will constantly
        // be changing as we take cards in and out
        private List<Card> cardDeck = new List<Card>();

        // Populate the Deck of Cards using the Card defined 
        // in Card.cs

        public Deck()
        {
            //cardDeck = new List<Card>();
            for (int suitValue = 0; suitValue <= 3; suitValue++)
            {
                for (int cardFace = 1; cardFace <= 13; cardFace++)
                {
                    cardDeck.Add(new Card((Suits)suitValue, (FaceValue)cardFace));
                }
            }
        }

        public List<Card> CardDeck
        {
            get { return cardDeck; }
        }

        // Return this instance of the card Deck
        public List<Card> getCardDeck()
        {
            return cardDeck;
        }

        // Method that should be able to draw a card from the deck
        public Card drawCard()
        {
            // Pick a random index for a card to remove
            int cardToDraw = random.Next(cardDeck.Count);

            // Take the card that is at this given element
            Card cardReturn = cardDeck.ElementAt(cardToDraw);

            // Make sure to remove this card from the Deck
            cardDeck.RemoveAt(cardToDraw);

            // Return the card here
            return cardReturn;
        }

        // Need a method that will show the number of cards in the deck

        public int cardDeckSize()
        {
            return cardDeck.Count;
        }

    }
}
