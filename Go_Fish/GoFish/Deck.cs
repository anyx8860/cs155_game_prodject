using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Deck
    {
        private Stack<Card> cards = new Stack<Card>();
        private List<Card> list = new List<Card>();

        public Deck()
        {            
            CreateCards();
            Shuffle();
            LoadDeck();
        }

        public Deck(Deck deck)
        {
            cards = deck.cards;
        }

        private void CreateCards()
        {
            for(int i = 2; i <= 14; i++)
            {
                Card hearts = new Card(Suits.Hearts, (Faces)i);
                Card spades = new Card(Suits.Spades, (Faces)i);
                Card clubs = new Card(Suits.Clubs, (Faces)i);
                Card diamonds = new Card(Suits.Diamonds, (Faces)i);

                list.Add(hearts);
                list.Add(spades);
                list.Add(clubs);
                list.Add(diamonds);
            }
        }

        private void LoadDeck()
        {
            foreach(Card card in list)
            {
                cards.Push(card);
            }
        }

        private static Random rng = new Random();

        private void Shuffle()
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = list[k];
                list[k] = list[n];
                list[n] = card;
            }
        }

        public void AddCard(Card card)
        {
            cards.Push(card);
        }

        public Card TakeCard()
        {
            return cards.Pop();
        }

        public int GetCardsLeft()
        {
            return cards.Count;
        }

        public bool IsEmpty()
        {
            return GetCardsLeft() == 0;
        }

        public override string ToString()
        {
            string deck_str = "";
            foreach(Card card in cards)
            {
                deck_str += "\n" + card.ToString();
            }
            return deck_str;
        }
    }
}
