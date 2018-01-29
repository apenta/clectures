using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Classes;

namespace Code.Tests
{
    [TestClass]
    public class MakeOutWordTests
    {
        [TestMethod]
        public void FourLetterOutWord_ConcatenatesAroundWord()
        {
            //Arrange
            MakeOutWordClass testClass = new MakeOutWordClass();

            //Act
            string result = testClass.MakeOutWord("<<>>", "Hello World!");

            //Assert
            Assert.AreEqual("<<Hello World!>>", result);
        }


        [TestMethod]
        public void NullOfEmptyString_ReturnsOriginalString()
        {
            //Arrange
            MakeOutWordClass testClass = new MakeOutWordClass();

            //Act
            string result = testClass.MakeOutWord("", "Hello World!");
            string result2 = testClass.MakeOutWord(null, "Hello World!");

            //Assert
            Assert.AreEqual("Hello World!", result, "Zero-length string should return original string");
            Assert.AreEqual("Hello World!", result2, "null string should return original string.");
        }



    }
}
