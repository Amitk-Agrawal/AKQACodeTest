using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.CodeTest.Service;

namespace AKQA.CodeTest.Tests
{
    [TestClass]
    public class CurrencyHandler_Test
    {
        [TestMethod]
        public void ConvertToWorld_Negative()
        {
            decimal amount = -1;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("- one dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Zero()
        {
            decimal amount = 0;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("zero dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_lessThanOne()
        {
            decimal amount = 0.99M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Ninety nine cents", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_One()
        {
            decimal amount = 1;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One dollar", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_Ten()
        {
            decimal amount = 10;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Ten Dollars", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_Hundred()
        {
            decimal amount = 101.01M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One Hundred and one Dollars and one cent", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_DollorAndCents()
        {
            decimal amount = 87342.456M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Eighty seven thousand three hundred and forty two dollars and forty five cents", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_Million()
        {
            decimal amount = 1234567.12M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("One million  two hundred and thirty four thousand five hundred and sixty seven dollars and twelve cents", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_Billion()
        {
            decimal amount = 3451234876.54M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Three billion  four hundred and fifty one million  two hundred and thirty four thousand eight hundred and seventy six dollars and fifty four cents", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_Trillion()
        {
            decimal amount = 5671234567123.06M;
            string words = AmountHandler.ConvertToWord(amount);

            Assert.AreEqual("Five trillion  six hundred and seventy one billion  two hundred and thirty four million  five hundred and sixty seven thousand one hundred and twenty three dollars and six cents", words, true);
        }

        [TestMethod]
        public void ConvertToWorld_Input_VeryLarge()
        {
            decimal amount = 12312345645678978956712345671.06M;
            OverflowException expectedExcetpion = null;

            try
            {
                AmountHandler.ConvertToWord(amount);
            }
            catch(OverflowException ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }
    }

}
