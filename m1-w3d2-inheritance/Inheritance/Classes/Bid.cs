using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Classes
{
    public class Bid
    {
        /// <summary>
        /// Name of the bidder
        /// </summary>
        public string Bidder { get; }

        /// <summary>
        /// Amount of bid (in whole dollars).
        /// </summary>
        public int BidAmount { get; }

        /// <summary>
        /// Creates a new bid.
        /// </summary>
        /// <param name="bidder">name of the bidder</param>
        /// <param name="bidAmount">amount of the bid</param>
        public Bid(string bidder, int bidAmount)
        {
            Bidder = bidder;
            BidAmount = bidAmount;
        }

    }
}
