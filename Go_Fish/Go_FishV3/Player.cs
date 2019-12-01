using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_FishV3
{
    class Player
    {
        private string _name; 
        private List<Card> hand = new List<Card>();

        private List<Card> books = new List<Card>();
        private int _num_of_books;
     
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Card> Hand
        {
            get { return hand; }
        }

        public List<Card> Books
        {
            get { return books; }
        }

        public int Num_Of_Books
        {
            get { return _num_of_books; }
        }

        public Player(string name, Deck deck)
        {
            Name = name;
            for (int i = 0; i < 7; i++)
            {
                hand.Add(deck.TakeCard());
            }
        }

        public override string ToString()
        {
            string hand_str = "[ ";

            foreach (Card card in hand)
            {
                if (hand.IndexOf(card) == hand.Count - 1)
                {
                    hand_str += card.ToString() + " ]";
                }
                else
                {
                    hand_str += card.ToString() + ", ";
                }

            }

            return Name + "\nHand: " + hand_str;
        }

        public void DrawCard(Deck deck)
        {
            hand.Add(deck.TakeCard());
        }

        public void AddCardToHand(Card card)
        {
            hand.Add(card);
        }

        public Card RemoveCardFromHand(Card card)
        {
            hand.Remove(card);
            return card;
        }

        public bool AskForCards(Player other_player, Faces face)
        {
            if(other_player.HasCard(face))
            {
                other_player.GiveCards(this, face);
                return true;
            }

            return false;
        }

        public void GiveCards(Player other_player, Faces face)
        {
            foreach(Card card in hand)
            {
                if(card.Face == face)
                {
                    other_player.AddCardToHand(RemoveCardFromHand(card));
                }
            }
        }

        public bool HasCard(Faces face)
        {
            foreach (Card card in hand)
            {
                if (card.Face == face)
                {
                    return true;
                }
            }

            return false;
        }

        public void GetBook(Faces face)
        {
            int count = 0;
            foreach (Card card in hand)
            {
                if (card.Face == face)
                {
                    count++;
                }
            }

            if (count == 4)
            {
                foreach (Card card in hand)
                {
                    if (card.Face == face)
                    {
                        books.Add(card);
                        hand.Remove(card);
                    }
                }
            }
        }

        public void GetAllBooks()
        {
            for(int i = 2; i <= 14; i++)
            {
                GetBook((Faces)i);
            }
        }
    }
}
