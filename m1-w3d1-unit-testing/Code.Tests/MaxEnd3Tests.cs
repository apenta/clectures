using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Classes;

namespace Code.Tests
{
    [TestClass]
    public class MaxEnd3Tests
    {
        [TestMethod]
        public void LastElementInArray_IsLargest()
        {
            //Arrange
            MaxEnd3Class testClass = new MaxEnd3Class();

            //Act
            int[] result = testClass.MaxEnd3(new int[] { 1, 2, 3 });

            //Assert
                                        // expected          actual
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);
        }
    }
}
