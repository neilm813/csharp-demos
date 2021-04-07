using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Card Draw(Deck deck)
        {
            Card dealtCard = deck.Deal();

            if (dealtCard != null)
            {
                Hand.Add(dealtCard);
            }

            return dealtCard;
        }
    }
}