using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Cards
{
    /// <summary>
    /// Represent an official standard card.
    /// </summary>
    public class StandardCard : Card
    {


        /// <summary>
        /// Property to determine if the card has a face.
        /// </summary>
        public bool IsFaceCard
        {
            get => (Rank == Ranks.Jack || Rank == Ranks.Queen || Rank == Ranks.King); //simple boolean expression
            //{
            //    return (Rank == Ranks.Jack || Rank == Ranks.Queen || Rank == Ranks.King);
            //}
        }


        /// <summary>
        /// Mapping between suits and characters.
        /// </summary>
        static Dictionary<Suits, char> symbols = new Dictionary<Suits, char>
        {
            {Suits.Spades, '\u2660'},
            {Suits.Diamonds, '\u2666'},
            {Suits.Clubs, '\u2663'},
            {Suits.Hearts, '\u2665'}
        };

        /// <summary>
        /// Determines which color the card is.
        /// </summary>
        public override ConsoleColor ForegroundColor
        {
            get
            {
                if (Suit == Suits.Clubs || Suit == Suits.Spades)
                {
                    return ConsoleColor.Black;
                }
                else
                {
                    return ConsoleColor.Red;
                }
            }
        }


        /// <summary>
        /// The suit for this standard card.
        /// </summary>
        public Suits Suit { get; }

        /// <summary>
        /// The rank for this standard card.
        /// </summary>
        public Ranks Rank { get; }

        /// <summary>
        /// Creates a new standard card.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        public StandardCard(Suits suit, Ranks rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }

        /// <summary>
        /// Prints out the user-friendly screen value for the card.
        /// </summary>
        /// <returns></returns>
        public override string GetDisplayValue()
        {
            string result = "";

            if(Rank == Ranks.Ace || Rank == Ranks.Ten || IsFaceCard)
            {
                result += Rank.ToString().Substring(0, 1); // Get the first character of the rank
            }
            else
            {
                result += (int)Rank; // Turns Two into 2
            }

            result += symbols[Suit]; // get our symbol using the current Suit property

            return result;
        }

        /// <summary>
        /// Compares two card ranks against each other.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override int CompareTo(Card other)
        {
            StandardCard otherCard = other as StandardCard;

            // + number means this card is greater than other card
            // - number means this card is less than other card
            // 0 means this card is equal to other card

            if (this.Rank == otherCard.Rank) // tie
            {
                return 0;
            }

            if (this.Rank == Ranks.Ace) // i have the ace
            {
                return 1;
            }
            else if (otherCard.Rank == Ranks.Ace) // you have the ace
            {
                return -1;
            }
            else
            {
                return this.Rank - otherCard.Rank; // e.g. my 9 - your 2 yields a positive number, my 2 - your 9 yields a negative number
            }

        }


        /// <summary>
        /// The possible suit values a card can have.
        /// </summary>
        public enum Suits
        {
            Spades,
            Clubs,
            Hearts,
            Diamonds
        }

        /// <summary>
        /// The different rank values.
        /// </summary>
        public enum Ranks
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

    }
}
