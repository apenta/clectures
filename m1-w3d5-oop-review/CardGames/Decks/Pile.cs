using CardGames.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Decks
{
    /// <summary>
    /// Represents a "pile" with a name.
    /// </summary>
    public class Pile
    {
        /// <summary>
        /// Creates a new pile.
        /// </summary>
        /// <param name="name"></param>
        public Pile(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Draws the top card from the pile.
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            Card output = null;

            // If there are cards
            if (HasCards)
            {
                // Get the first card
                output = Cards[0];
                // Remove card from the pile
                Cards.RemoveAt(0);
            }

            return output;
        }

        /// <summary>
        /// Adds a card to the pile.
        /// </summary>
        /// <param name="c"></param>
        public void Add(Card c)
        {
            Cards.Add(c);
        }

        /// <summary>
        /// Returns if the pile has any cards remaining.
        /// </summary>
        public bool HasCards { get => Cards.Count > 0; }

        /// <summary>
        /// Returns the amount of cards remaining in the pile.
        /// </summary>
        public int CardCount { get => Cards.Count; }

        /// <summary>
        /// Name of the pile
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The cards in the pile.
        /// </summary>
        private IList<Card> Cards { get; } = new List<Card>();


        

    }
}
