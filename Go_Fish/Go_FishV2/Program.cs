using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Go_Fish
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Initialize a new deck of cards for the game
            Deck gameDeck = new Deck();

            // Print out each card in the deck to ensure the values look right
            foreach (Card cardOut in gameDeck.getCardDeck())
            {
                Console.WriteLine(cardOut.toString());
            }
            Console.WriteLine();

            // Make sure that there are 52 cards in the deck
            Console.WriteLine("The current number of cards in the deck is {0}", gameDeck.cardDeckSize());

            // Create a player object
            Player player1 = new Player();

            // Create a second player object
            Player player2 = new Player();

            // Check to see that each player has a hand of cards
            // Method returns a list, therefore we will need to print the list
            player1.getPlayerHand();

            Console.WriteLine("Player 1's hand is: ");
            foreach (Card playerCard in player1.getPlayerHand())
            {
                Console.WriteLine(playerCard.toString());
            }
            Console.WriteLine();
            // Check that the second player has a hand that is unique from the first player's hand 

            player2.getPlayerHand();

            Console.WriteLine("Player 2's hand is: ");
            foreach (Card player2Card in player2.getPlayerHand())
            {
                Console.WriteLine(player2Card.toString());
            }
            Console.WriteLine();

            // Check that the number of cards in the deck has decremented - returns an integer, therefore we will need to print it
            player1.getDeckSize();

            Console.Write("Cards left after player 1's hand: {0}", player1.getDeckSize());
            Console.WriteLine();

            // Game plays while the number of books is under 26
            while (player1.getNumberOfBooks() + player2.getNumberOfBooks() < 26)
            {
                player1.takeATurn();
                Console.WriteLine();
                player2.takeATurn();
                Console.WriteLine();
            }

            // To check each player's score we need to get the number of books
            int player1Score = player1.getNumberOfBooks();
            int player2Score = player2.getNumberOfBooks();

            if (player1Score > player2Score)
            {
                Console.WriteLine("Congratulations Player 1! You win with a score of {0} books!", player1Score);
            }
            else if (player2Score > player1Score)
            {
                Console.WriteLine("Congratulations Player 2! You win with a score of {0} books!", player2Score);
            }
            else
            {
                Console.WriteLine("Its a tie!");
            }

            Console.ReadKey();
        }
    }
}
