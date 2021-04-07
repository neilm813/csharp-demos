using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            // You can brute force, manually construct 52 cards and add them to the Cards property. Or you can use a loop.

            Cards = new List<Card>();

            string[] suites = new string[4]
            {
                "Hearts",
                "Diamonds",
                "Clubs",
                "Spades"
            };

            Dictionary<int, string> cardNamesTable = new Dictionary<int, string>()
            {
                // {key, value}
                {1 , "Ace"},
                {11 , "Jack"},
                {12 , "Queen"},
                {13 , "King"},
            };

            // Alternatively, add key value pairs (KVPs) this way.
            // cardNamesTable.Add(1, "Ace");
            // cardNamesTable.Add(10, "Ten");

            foreach (string suite in suites)
            {
                for (int i = 1; i < 14; i++)
                {
                    string cardName = i.ToString();

                    if (cardNamesTable.ContainsKey(i))
                    {
                        // Retrieve the card name from the dict.
                        cardName = cardNamesTable[i];
                    }

                    Card currentCard = new Card(cardName, suite, i);

                    Cards.Add(currentCard);
                }
            }
        }

        public Card Deal()
        {
            if (Cards.Count == 0)
            {
                return null;
            }

            Card firstCard = Cards[0];
            Cards.RemoveAt(0);
            return firstCard;
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                int randIdx = rand.Next(0, Cards.Count);

                Card temp = Cards[i];
                Cards[i] = Cards[randIdx];
                Cards[randIdx] = temp;
            }
        }

        public override string ToString()
        {
            string deckStr = "";

            foreach (Card card in Cards)
            {
                deckStr += "\n" + card;
            }

            return deckStr;
        }
    }
}