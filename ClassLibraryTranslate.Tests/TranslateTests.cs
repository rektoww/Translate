using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryTranslate;

namespace ClassLibraryTranslate.Tests
{
    [TestClass]
    public class TranslateTests
    {
        // Строка, содержащая все возможные цифры для всех систем счисления
        private const string DIGITS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Проверяет корректность перевода целой части числа из двоичной системы в десятичную
        /// </summary>
        [TestMethod]
        public void ConvertIntegerPart_Base2To10()
        {
            string integerPart = "1010"; // 1010(2) = 10(10)
            int P = 2;
            double decimalValue = 0;

            Translate.ConvertIntegerPart(integerPart, P, DIGITS, ref decimalValue);

            Assert.AreEqual(10.0, decimalValue);
        }

        /// <summary>
        /// Проверяет корректность перевода целой части числа из шестнадцатеричной системы в десятичную
        /// </summary>
        [TestMethod]
        public void ConvertIntegerPart_Base16To10()
        {
            string integerPart = "1A"; // 1A(16) = 26(10)
            int P = 16;
            double decimalValue = 0;

            Translate.ConvertIntegerPart(integerPart, P, DIGITS, ref decimalValue);

            Assert.AreEqual(26.0, decimalValue);
        }

        /// <summary>
        /// Проверяет корректность перевода дробной части числа из двоичной системы в десятичную
        /// </summary>
        [TestMethod]
        public void ConvertFractionalPart_Base2To10()
        {
            string fractionalPart = "101"; // 0.101(2) = 0.625(10)
            int P = 2;
            double decimalValue = 0;

            Translate.ConvertFractionalPart(fractionalPart, P, DIGITS, ref decimalValue);

            Assert.AreEqual(0.625, decimalValue);
        }

        /// <summary>
        /// Проверяет корректность перевода дробной части числа из шестнадцатеричной системы в десятичную
        /// </summary>
        [TestMethod]
        public void ConvertFractionalPart_Base16To10()
        {
            string fractionalPart = "8"; // 0.8(16) = 0.5(10)
            int P = 16;
            double decimalValue = 0;

            Translate.ConvertFractionalPart(fractionalPart, P, DIGITS, ref decimalValue);

            Assert.AreEqual(0.5, decimalValue);
        }

        /// <summary>
        /// Проверяет корректность перевода целого числа из десятичной системы в двоичную
        /// </summary>
        [TestMethod]
        public void ConvertFromDecimalToBaseQInteger_Decimal_To_Binary()
        {
            long integerPart = 10; // 10(10) = 1010(2)
            int Q = 2;

            string result = Translate.ConvertFromDecimalToBaseQInteger(integerPart, Q, DIGITS);

            Assert.AreEqual("1010", result);
        }

        /// <summary>
        /// Проверяет корректность обработки нуля при переводе в другую систему счисления
        /// </summary>
        [TestMethod]
        public void ConvertFromDecimalToBaseQInteger_Zero()
        {
            long integerPart = 0;
            int Q = 2;

            string result = Translate.ConvertFromDecimalToBaseQInteger(integerPart, Q, DIGITS);

            Assert.AreEqual("0", result);
        }

        /// <summary>
        /// Проверяет корректность перевода простой дробной части из десятичной системы
        /// </summary>
        [TestMethod]
        public void ConvertFromDecimalToBaseQFractional_Simple()
        {
            string result = "0";  
            double fractionalPart = 0.5; // 0.5(10) = 0.1(2)
            int Q = 2;
            int accuracy = 4;

            Translate.ConvertFromDecimalToBaseQFractional(ref result, fractionalPart, Q, accuracy, DIGITS);

            Assert.AreEqual("01", result);  
        }

        /// <summary>
        /// Проверяет корректность разделения десятичного числа на целую и дробную части
        /// </summary>
        [TestMethod]
        public void SplitDecimalValue_WithFraction()
        {
            double decimalValue = 10.75; // Проверяем разделение числа 10.75

            Translate.SplitDecimalValue(decimalValue, out long integerPart, out double fractionalPart);

            // Допустимая погрешность при работе с double
            Assert.AreEqual(10, integerPart);
            Assert.AreEqual(0.75, fractionalPart, 0.000001);
        }

        /// <summary>
        /// Проверяет корректность разделения строкового представления числа с дробной частью
        /// </summary>
        [TestMethod]
        public void SplitNumber_WithFraction()
        {
            string number = "10.75";

            string[] parts = Translate.SplitNumber(number);

            // Проверяем корректность разделения на две части
            Assert.AreEqual(2, parts.Length);
            Assert.AreEqual("10", parts[0]);
            Assert.AreEqual("75", parts[1]);
        }

        /// <summary>
        /// Проверяет корректность разделения строкового представления целого числа
        /// </summary>
        [TestMethod]
        public void SplitNumber_WithoutFraction()
        {
            string number = "10";

            string[] parts = Translate.SplitNumber(number);

            // Проверяем, что для целого числа возвращается массив из одного элемента
            Assert.AreEqual(1, parts.Length);
            Assert.AreEqual("10", parts[0]);
        }

        /// <summary>
        /// Проверяет корректность перевода числа из двоичной системы в десятичную
        /// </summary>
        [TestMethod]
        public void ConvertNumber_Binary_To_Decimal()
        {
            string number = "1010.1"; // 1010.1(2) = 10.5(10)
            int P = 2;
            int Q = 10;
            int accuracy = 3;

            string result = Translate.ConvertNumber(number, P, Q, accuracy);

            Assert.AreEqual("10.5", result);
        }

        /// <summary>
        /// Проверяет корректность перевода числа из шестнадцатеричной системы в двоичную
        /// </summary>
        [TestMethod]
        public void ConvertNumber_Hex_To_Binary()
        {
            string number = "1F.8"; // 1F.8(16) = 11111.1(2)
            int P = 16;
            int Q = 2;
            int accuracy = 4;

            string result = Translate.ConvertNumber(number, P, Q, accuracy);

            Assert.AreEqual("11111.1", result);
        }
    }
}

