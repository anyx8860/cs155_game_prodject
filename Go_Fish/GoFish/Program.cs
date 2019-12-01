using System;

namespace GoFish
{
    class Program
    {
        static Deck deck = new Deck();
        static void Main(string[] args)
        {          
            // Create players
            Player player = new Player("", deck);
            Player cpu = new Player("CPU", deck);

            // App introduction and player name input
            Console.Write("Welcome to Go Fish!\nPlease enter your name: ");
            string name = Console.ReadLine();
            player.Name = name;

            // While both players still have cards, keep playing rounds
            while(cpu.Num_Of_Cards > 0 || player.Num_Of_Cards > 0)
            {
                PlayRoundWithCPU(player, cpu);
            }

            // Output the winner
            if(cpu.Num_Of_Books > player.Num_Of_Books) {
                Console.WriteLine("{0} wins!", cpu.Name);
            }
            else
            {
                Console.WriteLine("{0} wins!", player.Name);
            }

            Console.ReadKey();
        }

        // A round of the game with a CPU 
        public static void PlayRoundWithCPU(Player player, Player cpu) {
            PlayerTurn(player, cpu);
            CPUTurn(cpu, player);
        }

        // Player Turn
        public static void PlayerTurn(Player player1, Player player2)
        {
            // Prints initial turn info
            Console.WriteLine();
            player1.GetAllBooks(); // Checks for any books in the initial hand
            Console.WriteLine();
            Console.WriteLine(player1.ToString());  // Prints player's hand         
            Console.WriteLine("{0}'s Books: {1}", player1.Name, player1.Num_Of_Books); // Prints number of books
            Console.WriteLine();

            // Reads in player's choice of face to ask other player for.
            Console.Write("What card face would you like to ask for?\nEnter face here (ex. Two): ");
            string face_str = Console.ReadLine();
            Faces face = (Faces)Enum.Parse(typeof(Faces), face_str);
           
            while(player1.AskForCards(player2, face)) // While AskForCards() returns true
            {
                Console.WriteLine();

                // Prints what cards player took from other player (if statement to deal with the 'es' that must be added to 'six' in plural)
                if(face == Faces.Six)
                {
                    Console.WriteLine("You took {0}'s {1}es.", player2.Name, face);
                }
                else 
                {
                    Console.WriteLine("You took {0}'s {1}s.", player2.Name, face);
                }        
                Console.WriteLine();
                player1.GetAllBooks(); // Gets all books before printing hand
                Console.WriteLine(player1.ToString()); // Prints hand after player gets all cards from other player
                Console.WriteLine();               
                Console.WriteLine("{0}'s Books: {1}", player1.Name, player1.Num_Of_Books);
                Console.WriteLine();

                // Prompts player to ask for more cards since the last ask was successful
                Console.Write("What card face would you like to ask for?\nEnter face here (ex. Two): "); 
                face_str = Console.ReadLine();
                face = (Faces)Enum.Parse(typeof(Faces), face_str);
            }

            // Prints if AskForCards() returns false
            Console.WriteLine();
            if(face == Faces.Six)
            {
                Console.WriteLine("{0} doesn't have any {1}es. Go Fish!", player2.Name, face);
            }
            else 
            {
                Console.WriteLine("{0} doesn't have any {1}s. Go Fish!", player2.Name, face);
            }     
           
            player1.DrawCard(deck); // Player goes fishing
            Console.WriteLine("Cards left in the deck: {0}", deck.GetCardsLeft()); // Prints cards left in deck
        }

        // CPU Turn
        public static void CPUTurn(Player cpu, Player player)
        {
            Console.WriteLine();
            Console.WriteLine(cpu.Name);
            cpu.GetAllBooks();
            Console.WriteLine("{0}'s Books: {1}", cpu.Name, cpu.Num_Of_Books);

            int n = cpu.Num_Of_Cards - 1;
            Faces face = cpu.GetCardAtIndex(n).Face;

            while(cpu.AskForCards(player, face)) 
            {
                Console.WriteLine();
                if(face == Faces.Six){
                    Console.WriteLine("{0} took your {1}es.", cpu.Name, face);
                }
                else 
                {
                    Console.WriteLine("{0} took your {1}s.", cpu.Name, face);
                }                
                cpu.GetAllBooks();
                Console.WriteLine("{0}'s Books: {1}", cpu.Name, cpu.Num_Of_Books);
                n = cpu.Num_Of_Cards - 1;
                face = cpu.GetCardAtIndex(n).Face;
            }

            Console.WriteLine();
            if(face == Faces.Six)
            {
                Console.WriteLine("{0} doesn't have any {1}es. Go Fish!", player.Name, face);
            }
            else 
            {
                Console.WriteLine("{0} doesn't have any {1}s. Go Fish!", player.Name, face);
            }                      
            cpu.DrawCard(deck);
            Console.WriteLine("Cards left in the deck: {0}", deck.GetCardsLeft());
        }
    }
}
