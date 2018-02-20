using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VM.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        /// <summary>
        /// Validates that money can be fed into the machine and the balance increases.
        /// </summary>
        [TestMethod]
        public void FeedMoney_Tests()
        {
            VendingMachine vm = new VendingMachine(null);

            vm.FeedMoney(1);
            vm.FeedMoney(2);
            vm.FeedMoney(5);
            vm.FeedMoney(10);

            Assert.AreEqual(18.0M, vm.CurrentBalance);
        }

        /// <summary>
        /// Validates an exception is thrown when an invalid amount is fed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(VendingMachineException))]
        public void FeedMoney_Tests_InvalidDollarAmount()
        {
            //Arrange
            VendingMachine vm = new VendingMachine(null);

            //Act
            vm.FeedMoney(15);
        }

        /// <summary>
        /// Validates an exception is thrown when a negative amount is fed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(VendingMachineException))]
        public void FeedMoney_Tests_NegativeDollarAmount()
        {
            //Arrange
            VendingMachine vm = new VendingMachine(null);

            //Act
            vm.FeedMoney(-10);
        }

        /// <summary>
        /// Validates that Get Item At Slot returns the correct test product.
        /// </summary>
        [TestMethod]
        public void GetItemAtSlot_InStock()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            VendingMachineItem itemAtSlot = vm.GetItemAtSlot("A1");

            //Assert
            Assert.AreEqual(testItem, itemAtSlot);
        }

        /// <summary>
        /// Validates get item at slot with an invalid id throws an exception.
        /// Load A1 into the machine and ask for A2
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidSlotIDException))]
        public void GetItemAtSlot_InvalidSlot()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            VendingMachineItem itemAtSlot = vm.GetItemAtSlot("A2");
        }

        /// <summary>
        /// Validates get item at slot returns null if the slot is empty.
        /// </summary>
        [TestMethod]
        public void GetItemAtSlot_OutOfStock()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            VendingMachineItem itemAtSlot = vm.GetItemAtSlot("A1");

            //Assert
            Assert.AreEqual(null, itemAtSlot);
        }

        /// <summary>
        /// Validates get quantity remaining throws an invalid slot
        /// Loads A1 into the machine, asks for A2
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidSlotIDException))]
        public void GetQuantityRemaining_ThrowsInvalidSlot()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            int quantityRemaining = vm.GetQuantityRemaining("A2");
        }

        /// <summary>
        /// Validates get quantity remaining returns the valid quantity if the item is in stock.
        /// </summary>
        [TestMethod]
        public void GetQuantityRemaining_ReturnsValidQuantity()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            int quantityRemaining = vm.GetQuantityRemaining("A1");

            //Assert
            Assert.AreEqual(1, quantityRemaining);
        }

        /// <summary>
        /// Validates that return change gives back the proper change and the machine balance is reset to zero.
        /// </summary>
        [TestMethod]
        public void FinishTransactionTests_ReturnChange()
        {
            //Arrange
            VendingMachine vm = new VendingMachine(null);
            vm.FeedMoney(1);

            //Act
            Change returnedChange = vm.ReturnChange();

            //Assert
            Assert.AreEqual(0.0M, vm.CurrentBalance);
            Assert.IsNotNull(returnedChange);
            Assert.AreEqual(4, returnedChange.Quarters);
        }

        /// <summary>
        /// Validates an attempt to purchase from an invalid slot throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidSlotIDException))]
        public void Purchase_ThrowsInvalidSlot()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };

            //Act
            VendingMachine vm = new VendingMachine(inventory);

            //Assert
            vm.Purchase("A2");
        }

        /// <summary>
        /// Validates an attempt to purchase an out of stock item throws an out of stock exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(OutOfStockException))]
        public void Purchase_ThrowsOutOfStock()
        {
            //Arrange
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>()  }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            vm.Purchase("A1");
        }

        /// <summary>
        /// Validates an attempt to purchase an in stock item with no balance throrws insufficient funds.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void Purchase_ThrowsInsufficientFunds()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);

            //Act
            vm.Purchase("A1");
        }

        /// <summary>
        /// Validates a valid purchase properly returns the product, and deducts the balance and the stock amount accordingly.
        /// </summary>
        [TestMethod]
        public void Purchase_ValidPurchase()
        {
            //Arrange
            VendingMachineItem testItem = new VendingMachineItem("Test Chips", 1.25M);
            Dictionary<string, List<VendingMachineItem>> inventory = new Dictionary<string, List<VendingMachineItem>>()
            {
                {"A1", new List<VendingMachineItem>() {testItem} }
            };
            VendingMachine vm = new VendingMachine(inventory);            
            vm.FeedMoney(2);

            //Act
            VendingMachineItem purchasedItem = vm.Purchase("A1");

            //Assert
            Assert.IsNotNull(purchasedItem);
            Assert.AreEqual(0, inventory["A1"].Count);
            Assert.AreEqual(0.75M, vm.CurrentBalance);

        }
    }
}
