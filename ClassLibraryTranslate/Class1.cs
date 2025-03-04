using System;

namespace ClassLibraryTranslate
{
    public static class Translate
    {
        /// <summary>
        /// Выполняет задачу перевода целой части числа из системы счисления P в десятичную систему
        /// </summary>
        /// <param name="integerPart">целая часть исходного числа</param>
        /// <param name="P">система счисления, из которой переводится число</param>
        /// <param name="digits">строка всех возможных цифр в системе счисления</param>
        /// <param name="decimalValue">итоговая целая часть числа в десятичной системе</param>
        public static void ConvertIntegerPart(string integerPart, int P, string digits, ref double decimalValue)
        {
            for (int i = 0; i < integerPart.Length; i++)
            {
                int digitValue = digits.IndexOf(integerPart[i]);
                decimalValue += digitValue * Math.Pow(P, integerPart.Length - 1 - i);
            }
        }

        /// <summary>
        /// Выполняет задачу перевода дробной части числа из системы счисления P в десятичную систему
        /// </summary>
        /// <param name="fractionalPart">дробная часть исходного числа</param>
        /// <param name="P">система счисления, из которой переводится число</param>
        /// <param name="digits">строка всех возможных цифр в системе счисления</param>
        /// <param name="decimalValue">итоговая десятичная часть числа в десятичной системе</param>
        public static void ConvertFractionalPart(string fractionalPart, int P, string digits, ref double decimalValue)
        {
            for (int i = 0; i < fractionalPart.Length; i++)
            {
                int digitValue = digits.IndexOf(fractionalPart[i]);
                decimalValue += digitValue / Math.Pow(P, i + 1);
            }
        }

        /// <summary>
        /// Выполняет задачу перевода целой части исходного числа в десятичной системе счисления
        /// в систему счисления Q
        /// </summary>
        /// <param name="integerPart">целая часть исходного числа в десятичной системе счисления</param>
        /// <param name="Q">система счисления, в которую происходит перевод исходного числа</param>
        /// <param name="digits">строка всех возможных цифр в системе счисления</param>
        /// <returns></returns>
        public static string ConvertFromDecimalToBaseQInteger(long integerPart, int Q, string digits)
        {
            if (integerPart == 0)
            {
                return "0";
            }

            string result = "";
            while (integerPart > 0)
            {
                result = digits[(int)(integerPart % Q)] + result;
                integerPart /= Q;
            }
            return result;
        }

        /// <summary>
        /// Выполняет задачу перевода дробной части исходного числа в десятичной системе счисления
        /// в систему счисления Q
        /// </summary>
        /// <param name="result">переведённая в систему Q дробная часть исходного числа</param>
        /// <param name="fractionalPart">дробная часть исходного числа в десятичной системе счисления</param>
        /// <param name="Q">система счисления, в которую происходит перевод исходного числа</param>
        /// <param name="accuracy">точность, с которой происходит вывод числа в системе счисления Q</param>
        /// <param name="digits">строка всех возможных цифр в системе счисления</param>
        public static void ConvertFromDecimalToBaseQFractional(ref string result, double fractionalPart, int Q, int accuracy, string digits)
        {
            for (int i = 0; i < accuracy; i++)
            {
                fractionalPart *= Q;
                int fractionalDigit = (int)fractionalPart;
                result += digits[fractionalDigit];
                fractionalPart -= fractionalDigit;
                if (fractionalPart == 0) break;
            }
        }

        /// <summary>
        /// Выполняет задачу разделения десятичного числа на целую и дробную часть
        /// </summary>
        /// <param name="decimalValue">исходное число в системе счисления Q</param>
        /// <param name="integerPart">целая часть исходного числа в системе счисления Q</param>
        /// <param name="fractionalPart">дробная часть исходного числа в системе счисления Q</param>
        public static void SplitDecimalValue(double decimalValue, out long integerPart, out double fractionalPart)
        {
            integerPart = (long)decimalValue;
            fractionalPart = decimalValue - integerPart;
        }

        /// <summary>
        /// Выполняет задачу разделения исходного числа в системе счисления P на целую и дробную часть
        /// </summary>
        /// <param name="number">исходное числа в системе счисления P</param>
        /// <returns></returns>
        public static string[] SplitNumber(string number)
        {
            return number.Split('.');
        }
        /// <summary>
        /// Выполняет задачу перевода числа из системы счисления P в десятичную
        /// заьем в систему счисления Q
        /// </summary>
        /// <param name="number">исходное число в системе счисления P</param>
        /// <param name="P">система счисления исходного числа</param>
        /// <param name="Q">система счисления, в которую осуществляется перевод исходного числа</param>
        /// <param name="accuracy">точность вывода исходного числа, переведённого в систему счисления Q</param>
        /// <returns></returns>
        public static string ConvertNumber(string number, int P, int Q, int accuracy)
        {
            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double decimalValue = 0;

            // Разделение числа на целую и дробную часть
            string[] parts = SplitNumber(number);

            // Перевод целой части в десятичную систему
            ConvertIntegerPart(parts[0], P, digits, ref decimalValue);

            // Перевод дробной части в десятичную систему (если она существует)
            if (parts.Length > 1)
            {
                ConvertFractionalPart(parts[1], P, digits, ref decimalValue);
            }

            // Разделение десятичного значения на целую и дробную часть
            SplitDecimalValue(decimalValue, out long integerPart, out double fractionalPart);

            // Перевод из десятичной в систему Q
            string result = ConvertFromDecimalToBaseQInteger(integerPart, Q, digits);

            if (accuracy > 0 && fractionalPart > 0)
            {
                result += ".";
                ConvertFromDecimalToBaseQFractional(ref result, fractionalPart, Q, accuracy, digits);
            }

            return result;
        }
    }
}