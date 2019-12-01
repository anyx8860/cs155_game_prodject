using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Player
    {
        private string _name; 
        private List<Card> hand = new List<Card>();

        private int _num_of_cards;
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

        public int Num_Of_Cards 
        {
            get{ return _num_of_cards; }
            set{ _num_of_cards = value; }
        }

        public List<Card> Books
        {
            get { return books; }
        }

        public int Num_Of_Books
        {
            get { return _num_of_books; }
            set { _num_of_books = value; }
        }

        public Player(string name, Deck deck)
        {
            Name = name;
            Num_Of_Cards = 0;
            Num_Of_Books = 0;

            // Draws 7 cards and adds them to the player's hand
            for (int i = 0; i < 7; i++)
            {
                DrawCard(deck);
            }
        }

        public override string ToString()
        {
            SortHand();
            
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
            Num_Of_Cards++;
        }

        public void AddCardToHand(Card card)
        {
            hand.Add(card);
            Num_Of_Cards++;
        }

        public Card RemoveCardFromHand(Card card)
        {
            hand.Remove(card);
            Num_Of_Cards--;
            return card;
        }

        public void SortHand() 
        {
            hand.Sort();
        }

        public bool AskForCards(Player other_player, Faces face)
        {
            // If the other player has a card of the face you're asking for, they must give the card to you
            if(other_player.HasCard(face))
            {
                other_player.GiveCards(this, face);
                return true;
            }
            return false;
        }

        private void GiveCards(Player other_player, Faces face)
        {
            // Create a list of cards to be removed from the player's hand
            List<Card> cardsToRemove = new List<Card>();
            foreach(Card card in hand)
            {
                // If any card in the player's hand is the face the other player asked for, add it to the list
                if(card.Face == face)
                {
                    cardsToRemove.Add(card);
                }
            }

            // Remove any cards in the cardsToRemove list from the players hadn and add them to the other player's hand
            foreach(Card card in cardsToRemove)
            {
                this.RemoveCardFromHand(card);
                other_player.AddCardToHand(card);
            }
        }

        public Card GetCardAtIndex(int index) 
        {
            return hand.ElementAt(index);
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

        private void GetBook(Faces face)
        {
            List<Card> cardsToRemove = new List<Card>();
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
                Num_Of_Books++;
                foreach (Card card in hand)
                {
                    if (card.Face == face)
                    {
                        books.Add(card);
                        cardsToRemove.Add(card);
                    }
                }

                foreach(Card card in cardsToRemove) {
                    hand.Remove(card);
                    Num_Of_Cards--;
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
