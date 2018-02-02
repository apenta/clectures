using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    /// <summary>
    /// Represents a "card".
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// If the card is facing up.
        /// </summary>
        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Background color of our card.
        /// </summary>
        public virtual ConsoleColor BackgroundColor { get; protected set; } = ConsoleColor.White;

        /// <summary>
        /// Foreground color of our card.
        /// </summary>
        public virtual ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Black;


        /// <summary>
        /// Flips the card.
        /// </summary>
        public void Flip()
        {
            IsFaceUp = !IsFaceUp;
        }

        /// <summary>
        /// Prints the value on the card.
        /// </summary>
        /// <returns></returns>
        public abstract string GetDisplayValue();


    }
}
