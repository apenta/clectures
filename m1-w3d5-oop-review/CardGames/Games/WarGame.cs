using CardGames.Cards;
using CardGames.Decks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Games
{
    /// <summary>
    /// Represents the class card game of war.
    /// </summary>
    public class WarGame
    {
        /// <summary>
        /// Prints a nice message out indicating who drew what card.
        /// </summary>
        /// <param name="pile"></param>
        /// <param name="drawnCard"></param>
        private void PrintCard(Pile pile, Card drawnCard)
        {
            Console.Write($"{pile.Name.PadRight(20)}");

            Console.ResetColor();

            Console.BackgroundColor = drawnCard.BackgroundColor;
            Console.ForegroundColor = drawnCard.ForegroundColor;

            Console.Write(drawnCard.GetDisplayValue());

            Console.ResetColor();

            Console.WriteLine();
        }

        /// <summary>
        /// Plays a game of war.
        /// </summary>
        public void PlayGame()
        {
            // Create new war deck
            WarDeck deck = new WarDeck();

            // Shuffle the deck
            Console.WriteLine("Shuffling the deck.");
            deck.Shuffle();

            // Deal the deck into separate piles
            SeparateDeckIntoPiles(deck);

            // While Game isn't over
            while (!IsGameOver)
            {
                // Stop for 1/3 second before next hand
                System.Threading.Thread.Sleep(300);

                Console.Clear();

                // Player 1 & Player 2 Draw Card
                Card p1Card = PlayerOne.Draw();
                Card p2Card = PlayerTwo.Draw();

                PrintCard(PlayerOne, p1Card);
                PrintCard(PlayerTwo, p2Card);

                // Compare the Cards
                int compareResult = p1Card.CompareTo(p2Card);

                // If Player 1 card is less, add cards to Player 2
                if (compareResult < 0)
                {
                    Console.WriteLine($"{PlayerTwo.Name} wins the hand!");
                    PlayerTwo.Add(p1Card);
                    PlayerTwo.Add(p2Card);
                }
                // If Player 2 card is less, add cards to Player 1
                else if (compareResult > 0)
                {
                    Console.WriteLine($"{PlayerOne.Name} wins the hand!");
                    PlayerOne.Add(p1Card);
                    PlayerOne.Add(p2Card);
                }
                // Else a tie
                else
                {
                    Console.WriteLine("TIE. Both players will receive their cards back.");

                    // add cards back to each player's pile
                    PlayerOne.Add(p1Card);
                    PlayerTwo.Add(p2Card);
                }


                Console.WriteLine($"{PlayerOne.Name.PadRight(20)} {PlayerOne.CardCount} cards remaining");
                Console.WriteLine($"{PlayerTwo.Name.PadRight(20)} {PlayerTwo.CardCount} cards remaining");

            }

            // Declare winner
            PrintWinner();
        }

        private void PrintWinner()
        {
            Console.WriteLine($"{Winner.Name} is the winner!");
        }

        private void SeparateDeckIntoPiles(WarDeck deck)
        {
            int i = 0;

            // While there are cards in the deck
            while (deck.HasCards)
            {
                // Add a card to each pile, alternating
                if (i % 2 == 0)
                {
                    PlayerOne.Add(deck.Draw());
                }
                else
                {
                    PlayerTwo.Add(deck.Draw());
                }

                i++;
            }
        }

        /// <summary>
        /// Creates a new game of war.
        /// </summary>
        /// <param name="playerOneName"></param>
        /// <param name="playerTwoName"></param>
        public WarGame(string playerOneName, string playerTwoName)
        {
            PlayerOne = new Pile(playerOneName);
            PlayerTwo = new Pile(playerTwoName);
        }


        /// <summary>
        /// Represents Player Two's pile.
        /// </summary>
        private Pile PlayerTwo { get; }

        /// <summary>
        /// Represents Player One's pile.
        /// </summary>
        private Pile PlayerOne { get; }

        /// <summary>
        /// Retrurns true if one of the players has 0 cards remaining.
        /// </summary>
        public bool IsGameOver { get => (!PlayerOne.HasCards || !PlayerTwo.HasCards); }

        /// <summary>
        /// Returns the pile that is the winner.
        /// </summary>
        public Pile Winner
        {
            get
            {
                if (PlayerOne.HasCards && !PlayerTwo.HasCards)
                {
                    return PlayerOne;
                }
                else if (PlayerTwo.HasCards && !PlayerOne.HasCards)
                {
                    return PlayerTwo;
                }
                else
                {
                    return null; // there is no winner
                }
            }
        }
    }
}
