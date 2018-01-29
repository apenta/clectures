using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Classes;

namespace Code.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        [TestCategory("New Card")]
        public void NewCard_ValidateDefault_FaceDown()
        {
            // Arrange the test data we're working with
            Card card;

            // Act by calling the method we want to test
            card = new Card(1, "Hearts");

            // Assert by validating the objects have the correct value or return 
            // a valid output
            Assert.IsFalse(card.IsFaceUp, "New cards should be face down by default.");
            Assert.AreEqual(1, card.Value, "Card value must be set within constructor.");
            Assert.AreEqual("Hearts", card.Suit, "Card suit must be set within constructor");

        }

        [TestMethod]
        public void HeartsOrDiamonds_ShouldBeRed()
        {
            // Arrange
            Card card;
            Card diamondCard;            

            // Act
            card = new Card(1, "Hearts");
            diamondCard = new Card(1, "Diamonds");            

            // Assert
            Assert.AreEqual("Red", card.Color, "All hearts should be red.");
            Assert.AreEqual("Red", diamondCard.Color, "All diamonds should be red.");
        }

        [TestMethod]
        public void FlippedCard_ShouldBeFaceUpAfterwards()
        {
            //Arrange
            Card faceDownCard = new Card(1, "Hearts");

            //Act
            faceDownCard.Flip();

            //Assert
            Assert.IsTrue(faceDownCard.IsFaceUp, "A face down card that was flipped should now be face up");
        }




    }
}
