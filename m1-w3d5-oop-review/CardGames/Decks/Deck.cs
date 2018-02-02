using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Decks
{
    /// <summary>
    /// Represents a "deck"
    /// </summary>
    public abstract class Deck
    {
        /// <summary>
        /// The cards in the deck.
        /// IList<T> is used because we need to add, remove, clear, etc. our list.
        /// </summary>
        protected IList<Card> Cards { get; }

        /// <summary>
        /// A property that is derived and returns TRUE if count > 0.
        /// </summary>
        public bool HasCards { get => Cards.Count > 0; }


        /// <summary>
        /// Creates a new deck.
        /// </summary>
        public Deck()
        {
            Cards = BuildDeck();
        }

        /// <summary>
        /// Abstract method relies on subclasses to "build the deck".
        /// </summary>
        /// <returns></returns>
        protected abstract IList<Card> BuildDeck();

        /// <summary>
        /// Draws a single card
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            Card result = null;

            if (Cards.Count > 0)
            {
                result = Cards[0];
                Cards.RemoveAt(0);
            }

            return result;
        }

        /// <summary>
        /// Shuffles the deck.
        /// </summary>
        public void Shuffle()
        {
            Random r = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int randomSpot1 = r.Next(0, Cards.Count - 1);
                int randomSpot2 = r.Next(0, Cards.Count - 1);

                Card temp = Cards[randomSpot1];
                Cards[randomSpot1] = Cards[randomSpot2];
                Cards[randomSpot2] = temp;
            }
        }

    }
}
