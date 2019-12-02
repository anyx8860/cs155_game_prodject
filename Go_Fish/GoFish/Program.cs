using System;
using System.Collections.Generic;

namespace GoFish
{
    class Program
    {
        static Deck deck = new Deck();
        static List<string> str_list = new List<string>(new string[] {"Ace", "Two", "Three", "Four", "Five", "Six",
            "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"});

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
            while(player.Num_Of_Books < 7 && cpu.Num_Of_Books < 7)
            {
                PlayRoundWithCPU(player, cpu);
            }

            for(int i = 0; i < 10; i++)  
            {
                Console.WriteLine();
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

            if(player.Num_Of_Books >= 7 || cpu.Num_Of_Books >= 7) {
                return;
            }

            CPUTurn(cpu, player);
        }

        // Player Turn
        public static void PlayerTurn(Player player1, Player player2)
        {
            Console.Write("\n\n");
            Console.WriteLine("Cards left in the deck: {0}", deck.GetCardsLeft()); // Prints cards left in deck
            Console.WriteLine();
            DisplayPlayerInfo(player1);
            Console.WriteLine();

            if (player1.Num_Of_Books >= 7 || player2.Num_Of_Books >= 7) {
                return;
            }

            Faces face = ChooseFace(player1);
            
            while(player1.AskForCards(player2, face)) // While AskForCards() returns true
            {
                Console.WriteLine();
                DisplayFaceTakenFrom(player1, player2, face);
                Console.WriteLine("\n");
                DisplayPlayerInfo(player1);
                Console.WriteLine("\n");

                if (player1.Num_Of_Books >= 7 || player2.Num_Of_Books >= 7) 
                {
                    return;
                }           

                face = ChooseFace(player1);
            }

            // GoFish() if AskForCards() returns false
            Console.WriteLine();
            GoFish(player1, player2, face);
            Console.WriteLine("\n");
            DisplayPlayerInfo(player1);

            if(player1.Num_Of_Books >= 7 || player2.Num_Of_Books >= 7) 
            {
                return;
            }            
        }

        // CPU Turn
        public static void CPUTurn(Player cpu, Player player)
        {
            Console.Write("\n\n");
            Console.WriteLine("Cards left in the deck: {0}", deck.GetCardsLeft());
            Console.WriteLine();
            DisplayPlayerInfo(cpu);

            if(cpu.Num_Of_Books >= 7 || player.Num_Of_Books >= 7) 
            {
                return;
            }

            int n = cpu.Num_Of_Cards - 1;
            Faces face = cpu.GetCardAtIndex(n).Face;
            DrawCardIfHandIsEmpty(cpu);

            while(cpu.AskForCards(player, face)) 
            {
                Console.WriteLine();
                DrawCardIfHandIsEmpty(cpu);               
                DisplayFaceTakenFrom(cpu, player, face);
                Console.WriteLine();
                DisplayPlayerInfo(cpu);
                Console.WriteLine();

                if (cpu.Num_Of_Books >= 7 || player.Num_Of_Books >= 7) 
                {
                    return;
                }

                n = 0;
                face = cpu.GetCardAtIndex(n).Face;
            }

            Console.WriteLine();
            GoFish(cpu, player, face);
            Console.WriteLine("\n");
        }

        public static void DrawCardIfHandIsEmpty(Player player) {
            if(player.HandIsEmpty())
                {
                    player.DrawCard(deck);
                }
        }

        public static void GoFish(Player player1, Player player2, Faces face) 
        {
            if(face == Faces.Six)
            {
                Console.WriteLine("{0} doesn't have any {1}es. Go Fish!", player2.Name, face);
            }
            else 
            {
                Console.WriteLine("{0} doesn't have any {1}s. Go Fish!", player2.Name, face);
            }                      
            player1.DrawCard(deck);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayPlayerInfo(Player player)
        {
            DrawCardIfHandIsEmpty(player);           
            player.GetAllBooks(); // Checks for any books in the initial hand
            DrawCardIfHandIsEmpty(player);

            if(player.Name == "CPU")
            {
                Console.WriteLine("CPU");
            }
            else
            {
                Console.WriteLine(player.ToString());  // Prints player's hand 
            }
                   
            Console.WriteLine("{0}'s Books: {1}", player.Name, player.Num_Of_Books); // Prints number of books
        }

        public static Faces ChooseFace(Player player) 
        {
            // Reads in player's choice of face to ask other player for
            Console.Write("What card face would you like to ask for?\nEnter face here (ex. Two): ");
            string face_str = Console.ReadLine();
            Console.WriteLine();

            while(!player.HasCard(face_str))
            {               
                if(str_list.Contains(face_str)){
                    if(face_str == "Six")
                    {
                        Console.Write("You don't have hany {0}es. Please choose a face from your hand.\nEnter face: ", face_str);
                    }
                    else 
                    {
                        Console.Write("You don't have hany {0}s.  Please choose a face from your hand.\nEnter face: ", face_str);
                    }     
                    face_str = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("{0} is not a valid face.\nPlease enter a valid face here (ex. Ace, Two, Three...): ", face_str);
                    face_str = Console.ReadLine();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();

            Faces face = (Faces)Enum.Parse(typeof(Faces), face_str);

            return face;      
        }

        public static void DisplayFaceTakenFrom(Player player1, Player player2, Faces face) {
            if(face == Faces.Six)
            {
                Console.WriteLine("{0} took {1}'s {2}es.", player1.Name, player2.Name, face);
            }
            else 
            {
                Console.WriteLine("{0} took {1}'s {2}s.", player1.Name, player2.Name, face);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
