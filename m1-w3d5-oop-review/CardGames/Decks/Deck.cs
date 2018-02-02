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

    }
}
