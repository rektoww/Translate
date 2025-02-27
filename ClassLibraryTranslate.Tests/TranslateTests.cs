using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTranslate;

namespace ClassLibraryTranslate.Tests
{
    [TestClass]
    public class TranslateTests
    {
        [TestMethod]
        public void ConvertNumber_DecimalToBinary_ReturnsCorrectResult()
        {
       
            string number = "10";
            int fromBase = 10;
            int toBase = 2;
            int accuracy = 0;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("1010", result);
        }

        [TestMethod]
        public void ConvertNumber_BinaryToDecimal_ReturnsCorrectResult()
        {
            string number = "1010";
            int fromBase = 2;
            int toBase = 10;
            int accuracy = 0;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void ConvertNumber_DecimalFractionToHex_ReturnsCorrectResult()
        {
 
            string number = "10.5";
            int fromBase = 10;
            int toBase = 16;
            int accuracy = 4;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("A.8", result);
        }

        [TestMethod]
        public void ConvertNumber_HexToOctal_ReturnsCorrectResult()
        {
         
            string number = "FF";
            int fromBase = 16;
            int toBase = 8;
            int accuracy = 0;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("377", result);
        }

        [TestMethod]
        public void ConvertNumber_ZeroInAnyBase_ReturnsZero()
        {
       
            string number = "0";
            int fromBase = 10;
            int toBase = 2;
            int accuracy = 0;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void ConvertNumber_FractionWithAccuracy_ReturnsCorrectPrecision()
        {
     
            string number = "0.5";
            int fromBase = 10;
            int toBase = 2;
            int accuracy = 3;

            string result = Translate.ConvertNumber(number, fromBase, toBase, accuracy);

            Assert.AreEqual("0.1", result);
        }
    }
} 