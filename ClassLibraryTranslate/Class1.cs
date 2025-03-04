using System;

namespace ClassLibraryTranslate
{
    public static class Translate
    {
        /// <summary>
        /// Перевод целой части числа из системы счисления P в десятичную систему
        /// </summary>
        /// <param name="digitValue">числовое значение текущей цифры</param>
        /// <param name="integerPart">целая часть исходного числа</param>
        /// <param name="P">система счисления из которой переводится число</param>
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
        /// Перевод дробной части числа из системы счисления P в десятичную систему
        /// </summary>
        /// <param name="digitValue">числовое значение текущей цифры</param>
        /// <param name="fractionalPart">дробная часть исходного числа</param>
        /// <param name="P">система счисления из которой переводится число</param>
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
        /// 
        /// </summary>
        /// <param name="integerPart"></param>
        /// <param name="Q"></param>
        /// <param name="digits"></param>
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
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="fractionalPart"></param>
        /// <param name="Q"></param>
        /// <param name="accuracy"></param>
        /// <param name="digits"></param>
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
        /// 
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <param name="integerPart"></param>
        /// <param name="fractionalPart"></param>
        public static void SplitDecimalValue(double decimalValue, out long integerPart, out double fractionalPart)
        {
            integerPart = (long)decimalValue;
            fractionalPart = decimalValue - integerPart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string[] SplitNumber(string number)
        {
            return number.Split('.');
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        /// <param name="accuracy"></param>
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