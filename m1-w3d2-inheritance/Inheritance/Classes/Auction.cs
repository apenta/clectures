using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    /// <summary>
    /// Represents a general auction.
    /// </summary>
    public class Auction
    {
        /// <summary>
        /// The current high bid.
        /// </summary>
        public Bid HighBidder { get; private set; }

        /// <summary>
        /// All Bids for the auction.
        /// </summary>
        private List<Bid> Bids { get; set; } = new List<Bid>();

        /// <summary>
        /// Indicates if the auction has ended.
        /// </summary>
        public bool HasEnded { get; private set; }


        /// <summary>
        /// Places a bid on an auction.
        /// </summary>
        /// <param name="offer">Details of the bid offer.</param>
        /// <returns>true if the bid is a high bid.</returns>
        public bool PlaceBid(Bid offer)
        {
            bool winningBid = false;

            Console.WriteLine();
            Console.WriteLine($"Placing bid by {offer.Bidder.ToUpper()} for {offer.BidAmount.ToString("C")}");

            // Add the bid to the log
            Bids.Add(offer);

            // The first bidder will be the high bidder
            if (HighBidder == null)
            {
                HighBidder = offer;
                winningBid = true;
            }

            // Any new bidder must exceed the current high bidder
            if (offer.BidAmount > HighBidder.BidAmount)
            {
                Console.WriteLine($"High Bidder {HighBidder.Bidder.ToUpper()} has been outbid by {offer.Bidder.ToUpper()}!");

                // Replace the high bidder with offer
                HighBidder = offer;
                winningBid = true;
            }

            Console.WriteLine($"Current high bid is held by {HighBidder.Bidder.ToUpper()} for {HighBidder.BidAmount.ToString("C")}");
            Console.WriteLine();

            return winningBid;
        }
    }
}
