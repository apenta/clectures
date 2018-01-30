using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    public class BuyoutAuction : Auction
    {
        // We add a constructor because auction class defines one.
        public BuyoutAuction(string itemName, int buyoutPrice) : base(itemName)
        {
            this.BuyoutPrice = buyoutPrice;
        }

        /// <summary>
        /// Holds the buyout price
        /// </summary>
        public int BuyoutPrice { get; }

        public override bool PlaceBid(Bid offer)
        {
            bool hasWinningBid = false;

            if (HasEnded)
            {
                Console.WriteLine($"You are too late {offer.Bidder.ToUpper()}! Mwa ha ha!");
            }
            else
            {
                if (offer.BidAmount >= BuyoutPrice)
                {
                    Bid correctedOffer = new Bid(offer.Bidder, BuyoutPrice);
                    hasWinningBid = base.PlaceBid(correctedOffer);
                    HasEnded = true;
                    //offer.BidAmount = BuyoutPrice;

                    Console.WriteLine("AUCTION OVER!");
                    Console.WriteLine($"Winner is {HighBidder.Bidder.ToUpper()}");
                }
                else
                {
                    hasWinningBid = base.PlaceBid(offer);
                }

                // If the bid > buyout price
                    // adjust the bid by setting it equal to buyout value
                    // process the bid
                    // end the auction
                // else
                    // process the bid
            }

            return hasWinningBid;
        }


        



    }
}
