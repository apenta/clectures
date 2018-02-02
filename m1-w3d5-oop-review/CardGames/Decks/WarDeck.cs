using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Cards;

namespace CardGames.Decks
{
    /// <summary>
    /// Represents the deck for a game of war.
    /// </summary>
    public class WarDeck : Deck
    {
        /// <summary>
        /// Builds out the deck of 52 cards.
        /// </summary>
        /// <returns></returns>
        protected override IList<Card> BuildDeck()
        {
            List<Card> cards = new List<Card>();    //list that will hold the cards

            // Get all of the suit
            var suits = Enum.GetValues(typeof(StandardCard.Suits)).Cast<StandardCard.Suits>();

            // Get all of the ranks
            var ranks = Enum.GetValues(typeof(StandardCard.Ranks)).Cast<StandardCard.Ranks>();

            // Foreach through each suit
            foreach(var suit in suits)
            {
                // Foreach through each rank
                foreach (var rank in ranks)
                {
                    // Create a card and add to cards
                    StandardCard card = new StandardCard(suit, rank);
                    cards.Add(card);
                }
            }

            return cards;
        }
    }
}
