using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace Go_Fish
{
    class Player
    {
        private Random random = new Random();
        // What kind of information do we need to have for 
        // each player? - The instance variables

        private string playerName;
        public Deck cardDeck { get; set; }



        private List<Card> PlayerHand;

        public List<Card> getPlayerActualHand()
        {
            this.PlayerHand = cardDeck.getPlayerHand();
            return PlayerHand;
        }
        // Instance variable for number of Books


        // Empty Constructor
        public Player()
        {
            this.playerName = "Anonymous";
        }

        // Full Constructor
        public Player(string nameIn)
        {
            this.playerName = nameIn;
        }

        // Copy Constructor
        public Player(Player theObject)
        {
            this.playerName = theObject.getPlayerName();
        }

        // Getter and Setter methods
        public string getPlayerName()
        {
            return this.playerName;
        }

        public void setPlayerName()
        {
            Console.Write("Please enter your name: ");
            this.playerName = Console.ReadLine();
        }

        public void setDeck(Deck cardDeck)
        {
            this.cardDeck = cardDeck;
        }

        public Deck getDeck()
        {
            return this.cardDeck;
        }





        // Equals methods


        // To String method
        public string toString()
        {
            return string.Format("Player Name: {0}", this.playerName);
        }


        // Method to ask for a card?


        // Method so each player can peek at their cards?
        public void Peek(List<Card> playerHandIn)
        {
            foreach (Card handCard in playerHandIn)
            {
                Console.WriteLine(handCard.toString());
            }
            // Ask which card they would like to pick to ask 
            // their opponent, then call the ask for card method
            Console.Write("Which card would you like to pick?: ");
        }

    }
}


