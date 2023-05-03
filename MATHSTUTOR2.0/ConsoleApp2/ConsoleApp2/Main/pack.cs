using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.Main
{
    public class Pack
    {
        private readonly List<Card> cards;

        public Pack()
        {
            cards = new List<Card>();
            InitializeCards();
        }

        private void InitializeCards()
        {
            for (int i = 1; i <= 10; i++)
            {
                cards.Add(new Card { Number = i, Operator = "+" });
                cards.Add(new Card { Number = i, Operator = "-" });
                cards.Add(new Card { Number = i, Operator = "*" });
            }
        }

        public List<Card> GetCards(int count)
        {
            var shuffledCards = ShuffleCards();
            return shuffledCards.Take(count).ToList();
        }

        private List<Card> ShuffleCards()
        {
            var rng = new Random();
            return cards.OrderBy(c => rng.Next()).ToList();
        }
    }
}
