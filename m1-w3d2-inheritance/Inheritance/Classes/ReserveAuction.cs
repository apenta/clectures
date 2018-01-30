using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    /// <summary>
    /// A reserve auction is a specific type of auction.
    /// The minimum price must be met before considered as a bid.
    /// </summary>
    public class ReserveAuction : Auction
    {
        public ReserveAuction(string itemName, int minimumPrice) : base(itemName) // <-- calls the base class constructor
        {
            // Code that runs in the ReserveAuction constructor
            this.ReserveAmount = minimumPrice;
        }

        /// <summary>
        /// The minimum reserve price for the auction.
        /// </summary>
        public int ReserveAmount { get; private set; }


        public override bool PlaceBid(Bid offer)
        {
            bool isWinningBid = false;

            // Only going to consider a bid if the amount is >= reserve
            if(offer.BidAmount >= ReserveAmount)
            {
                // Process the bid
                // We don't duplicate the code for place bid here, instead we call the place bid method in the Auction class.
                isWinningBid = base.PlaceBid(offer);
            }
            else
            {
                Console.WriteLine($"Bid offered by {offer.Bidder.ToUpper()} does not meet the reserve ({ReserveAmount.ToString("C")}).");
            }


            return isWinningBid;
        }
    }
}
