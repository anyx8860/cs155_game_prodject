using System;

namespace Go_FishV3
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player1 = new Player("Player 1", deck);
            Player player2 = new Player("Player 2", deck);

            Console.WriteLine(player1.ToString());
            Console.WriteLine(player2.ToString());
        }
    }
}
