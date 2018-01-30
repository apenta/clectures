using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance.Classes;

namespace Inheritance.Tests.Classes
{
    [TestClass]
    public class BuyoutAuctionTests
    {
        [TestMethod]
        public void PlaceHighBid_BelowBuyout_ContinueAuction()
        {
            //Arrange
            BuyoutAuction auction = new BuyoutAuction("TEST", 100);
            Bid testBid = new Bid("FAKE BID NAME", 5);

            //Act
            bool result = auction.PlaceBid(testBid);

            //Assert
            Assert.IsFalse(auction.HasEnded);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PlaceBid_LargerThanBuyout_EndAuction()
        {
            //Arrange
            BuyoutAuction auction = new BuyoutAuction("TEST", 100);
            Bid testBid = new Bid("FAKE BIDDER NAME", 101);

            //Act
            bool result = auction.PlaceBid(testBid);

            //Assert
            Assert.IsTrue(auction.HasEnded);
            Assert.IsTrue(result);
        }
    }
}
