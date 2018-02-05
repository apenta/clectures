using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    [TestClass]
    public class KataRomanNumeralTests
    {
        KataRomanNumeral kata;

        [TestInitialize]
        public void Initialize()
        {
            kata = new KataRomanNumeral();
        }


        [TestMethod]
        public void Enter_1_Return_I()
        {  
            //Assert
            Assert.AreEqual("I", kata.GetRomanNumeral(1));
        }

        [TestMethod]
        public void Enter_5_Return_V()
        {
            //Assert
            Assert.AreEqual("V", kata.GetRomanNumeral(5));
        }

        [TestMethod]
        public void Enter_10_Return_X()
        {
            Assert.AreEqual("X", kata.GetRomanNumeral(10));
        }

        [TestMethod]
        public void Enter_50_Return_L()
        {
            Assert.AreEqual("L", kata.GetRomanNumeral(50));
        }

        [TestMethod]
        public void Enter_100_Return_C()
        {
            Assert.AreEqual("C", kata.GetRomanNumeral(100));
        }

        [TestMethod]
        public void Enter_500_Return_D()
        {
            Assert.AreEqual("D", kata.GetRomanNumeral(500));
        }

        [TestMethod]
        public void Enter_1000_Return_M()
        {
            Assert.AreEqual("M", kata.GetRomanNumeral(1000));
        }

        [TestMethod]
        public void Enter_2_Return_II()
        {
            Assert.AreEqual("II", kata.GetRomanNumeral(2));
        }

        [TestMethod]
        public void Enter_3_Return_III()
        {
            Assert.AreEqual("III", kata.GetRomanNumeral(3));
        }

        [TestMethod]
        public void Enter_4_Return_IV()
        {
            Assert.AreEqual("IV", kata.GetRomanNumeral(4));
        }

        [TestMethod]
        public void Enter_6_Return_VI()
        {
            Assert.AreEqual("VI", kata.GetRomanNumeral(6));
        }

        [TestMethod]
        public void Enter_7_Return_VII()
        {
            Assert.AreEqual("VII", kata.GetRomanNumeral(7));
        }

        [TestMethod]
        public void Enter_8_Return_VIII()
        {
            Assert.AreEqual("VIII", kata.GetRomanNumeral(8));
        }

        [TestMethod]
        public void Enter_9_Return_IX()
        {
            Assert.AreEqual("IX", kata.GetRomanNumeral(9));
        }

        [TestMethod]
        public void Enter_11_Return_XI()
        {
            Assert.AreEqual("XI", kata.GetRomanNumeral(11));
        }

        [TestMethod]
        public void Thousands()
        {
            Assert.AreEqual("MI", kata.GetRomanNumeral(1001));
            Assert.AreEqual("MII", kata.GetRomanNumeral(1002));
            Assert.AreEqual("MIII", kata.GetRomanNumeral(1003));
            Assert.AreEqual("MIV", kata.GetRomanNumeral(1004));

            Assert.AreEqual("MM", kata.GetRomanNumeral(2000));
            Assert.AreEqual("MMI", kata.GetRomanNumeral(2001));
        }

        [TestMethod]
        public void FiveHundreds()
        {
            Assert.AreEqual("DI", kata.GetRomanNumeral(501));
            Assert.AreEqual("DC", kata.GetRomanNumeral(600));
            Assert.AreEqual("DIV", kata.GetRomanNumeral(504));            
        }

        [TestMethod]
        public void Hundreds()
        {
            Assert.AreEqual("CI", kata.GetRomanNumeral(101));
            Assert.AreEqual("CI", kata.GetRomanNumeral(101));
            Assert.AreEqual("CDLXII", kata.GetRomanNumeral(462));
            Assert.AreEqual("CDXCIX", kata.GetRomanNumeral(499));
        }

        [TestMethod]
        public void Fifties()
        {
            Assert.AreEqual("LI", kata.GetRomanNumeral(51));

        }

        [TestMethod]
        public void Tens()
        {
            Assert.AreEqual("XI", kata.GetRomanNumeral(11));
            Assert.AreEqual("XXI", kata.GetRomanNumeral(21));
            Assert.AreEqual("XXXI", kata.GetRomanNumeral(31));
            Assert.AreEqual("XLI", kata.GetRomanNumeral(41));
            Assert.AreEqual("XCV", kata.GetRomanNumeral(95));
        }

    }
}
