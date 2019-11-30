using System;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Go_Fish
{
    public class Player
    {

        Random random = new Random();
        // Create a list that will be the playersHand 
        public List<Card> playerHand = new List<Card>();

        // Create an instance variable for the number of Books
        private int numberOfBooks;

        //public Deck cardDeck {get; set;}

        Deck cardDeck = new Deck();

        // Getter for the Deck
        public Deck getDeck()
        {
            return this.cardDeck;
        }

        // Setter for the deck 
        public void setDeck(Deck cardDeck)
        {
            this.cardDeck = cardDeck;
        }

        public int getDeckSize()
        {
            return cardDeck.cardDeckSize();
        }

        // Getter and Setter for the Number of Books
        public int getNumberOfBooks()
        {
            return this.numberOfBooks;
        }

        // Need a method to check if a book is present
        public Card bookAvailable()
        {
            foreach (Card bookCount in playerHand)
            {
                // Initialize placeholder to 0
                int number = 0;
                foreach (Card bookCompare in playerHand)
                {
                    if (bookCount == bookCompare)
                    {
                        number++;
                    }
                }
                if (number == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        playerHand.Remove(bookCount);
                    }
                    numberOfBooks++;
                    return bookCount;
                }
            }
            return null;
        }

        public Player(Deck cardDeck)
        {
            this.cardDeck = cardDeck;
        }

        // Create a constructor that will initialize the player's hand of cards the minute we create an instance of the player
        public Player()
        {
            for (int i = 0; i < 7; i++)
            {
                goFish();
            }
        }

        // Create a goFish method that will call the draw method for random cards
        public void goFish()
        {
            if (cardDeck.cardDeckSize() > 0)
            {
                playerHand.Add(cardDeck.drawCard());
            }
            else
            {
                Console.WriteLine("There are no more cards to pull.");
            }
        }

        // Create a method that will return the player's hand
        public List<Card> getPlayerHand()
        {
            return this.playerHand;
        }

        // Write a method that will check to see if a given card exists in the player's hand
        public bool handContains(Card cardValue)
        {
            return playerHand.Contains(cardValue);
        }

        // Method that will give all of the specified card value from one player to another
        public List<Card> giveToPlayer(Card cardValue)
        {
            // Create a new list to hold all cards being transferred
            List<Card> tempHand = new List<Card>();

            // Need to scan each card in the player's hand for the specified value
            for (int i = 0; i < playerHand.Count(); i++)
            {
                if (playerHand.ElementAt(i) == cardValue)
                {
                    tempHand.Add(playerHand.ElementAt(i));
                }
            }
            for (int j = 0; j < tempHand.Count; j++)
            {
                playerHand.Remove(cardValue);
            }
            return tempHand;
        }

        // Need a method so that one player can ask another for cards
        public bool askPlayer(Card cardValue)
        {
            //int temp = 0;

            Player other = new Player();
            //other = playerIn;
            if (other.handContains(cardValue))
            {
                foreach (Card cardExchange in other.giveToPlayer(cardValue))
                {
                    playerHand.Add(cardExchange);

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Each player needs to have the ability to execute their turn
        public void takeATurn()
        {
            // Shows that the game is currently being played
            bool playing = true;

            do
            {
                if (playerHand.Count == 0)
                {
                    Console.Write("You don't have any cards in your hand!");
                    goFish();
                    break;
                }
                else
                {
                    Console.WriteLine("Your current hand is: ");
                    foreach (Card cardHand in playerHand)
                    {
                        Console.WriteLine(cardHand.toString());
                    }
                }

                // Check to see if the player's hand has any books before asking for a specific card
                Card playerBook = bookAvailable();

                // Get the card to ask for
                Console.Write("Pick the value you'd like to get from your opponent: ");

                // Initialize a place to hold the value we want to receive
                Card requestedCard = null;
                FaceValue faceEnum;
                Suits suitEnum;
                // Use a try- catch incase an invalid card is chosen
                try
                {
                    string cardRequest = Console.ReadLine();
                    cardRequest = cardRequest.ToUpper();
                    if (Enum.TryParse(cardRequest, out faceEnum))
                    {
                        requestedCard.setFaceValue(faceEnum);
                    }
                    Console.Write("Pick the suit: ");
                    string suitRequest = Console.ReadLine();
                    if (Enum.TryParse(suitRequest, out suitEnum))
                    {
                        requestedCard.setCardSuit(suitEnum);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("This is not a valid card choice.");
                    continue;
                }

                // Check to see if you have a value of requestedCard in your hand
                if (!playerHand.Contains(requestedCard))
                {
                    Console.WriteLine("Please only choose cards you have in your hand.");
                    continue;
                }

                // Continues the game play
                playing = askPlayer(requestedCard);
            } while (playing);
            Console.Write("No luck, Go Fish!");
            goFish();
        }


    }
}
