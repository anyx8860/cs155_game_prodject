
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World");
                // Create the deck of cards for the Go_Fish Game
                Deck gameDeck = new Deck();

                // Print each card in the deck to make sure that
                // all cards are present - should be 52 total
                foreach (Card cardOut in gameDeck.getCardDeck())
                {
                    Console.WriteLine(cardOut.toString());
                    Console.WriteLine();
                }

                // Get the player's hand - should be seven random cards
                // from the original deck
                List<Card> player1Hand;
                player1Hand = gameDeck.getPlayerHand();

                foreach (Card playerCard in player1Hand)
                {
                    Console.WriteLine(playerCard.toString());
                }

                // Check how many cards are in the gameDeck - 
                // we removed 7 cards for the first player, should be
                // 45 cards left
                Console.WriteLine();
                Console.WriteLine("The number of cards in the deck now are: {0}", gameDeck.getCount());
                Console.WriteLine();


                // Create a Second hand of cards for a potential
                // second player
                Player player2 = new Player();
                List<Card> player2Hand;
                player2Hand = gameDeck.getPlayerHand();

                foreach (Card player2Card in player2Hand)
                {
                    Console.WriteLine(player2Card.toString());
                }


                // Make sure that the cards were removed from the deck
                // properly by checking how many cards are currently in
                // the deck - this should return 38

                Console.WriteLine();
                Console.WriteLine("The current number of cards in the deck is: {0}", gameDeck.getCount());


                // Test the peek method, if we were not printing out the cards to the console - theoretical







            }
        }
    }


