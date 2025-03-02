using System;

namespace ClassLibraryTranslate
{
    public static class Translate
    {
        // Метод для перевода целой части числа из системы счисления P в десятичную
        public static double ConvertIntegerPart(string integerPart, int P, string digits)
        {
            double decimalValue = 0;
            for (int i = 0; i < integerPart.Length; i++)
            {
                int digitValue = digits.IndexOf(integerPart[i]);
                decimalValue += digitValue * Math.Pow(P, integerPart.Length - 1 - i);
            }
            return decimalValue;
        }

        // Метод для перевода дробной части числа из системы счисления P в десятичную
        public static double ConvertFractionalPart(string fractionalPart, int P, string digits)
        {
            double decimalValue = 0;
            for (int i = 0; i < fractionalPart.Length; i++)
            {
                int digitValue = digits.IndexOf(fractionalPart[i]);
                decimalValue += digitValue / Math.Pow(P, i + 1);
            }
            return decimalValue;
        }

        public static string ConvertNumber(string number, int P, int Q, int accuracy)
        {
            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double decimalValue = 0;

            // Разделение числа на целую и дробную часть
            string[] parts = number.Split('.');

            // Перевод целой части в десятичную систему
            decimalValue += ConvertIntegerPart(parts[0], P, digits);

            // Перевод дробной части в десятичную систему (если она существует)
            if (parts.Length > 1)
            {
                decimalValue += ConvertFractionalPart(parts[1], P, digits);
            }

            // Перевод из десятичной в систему Q
            long integerPart = (long)decimalValue;
            double fractionalPart = decimalValue - integerPart;
            string result;

            // Формирование целой части результата
            if (integerPart == 0)
            {
                result = "0";
            }
            else
            {
                result = "";
            }

            // Преобразование целой части числа в систему Q
            while (integerPart > 0)
            {
                result = digits[(int)(integerPart % Q)] + result;
                integerPart /= Q;
            }

            // Обработка дробной части
            if (accuracy > 0 && fractionalPart > 0)
            {
                result += ".";
                for (int i = 0; i < accuracy; i++)
                {
                    fractionalPart *= Q;
                    int fractionalDigit = (int)fractionalPart;
                    result += digits[fractionalDigit];
                    fractionalPart -= fractionalDigit;
                    if (fractionalPart == 0) break;
                }
            }

            return result;
        }
    }
}
