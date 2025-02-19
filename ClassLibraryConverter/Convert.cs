using System;
/// <summary>
/// 
/// Задача переводчика: перевод числа в заданную систему счисления
/// 
/// </summary>
namespace ClassLibraryConverter
{
    /// <summary>
    /// 
    /// Перевод полученного числа в системе счисления P
    /// в десятичную систему счисления,
    /// затем перевод в требуемую систему счисления Q
    /// 
    /// </summary>
    /// <param name="number">начальное число</param>
    /// <param name="P">система счисления начального числа</param>
    /// <param name="Q">система счисления в которую нужно произвести перевод начального числа</param>
    /// <param name="accuracy">точность вывода результата</param>
    public static class Translate
    {
        public static string ConvertNumber(string number, int P, int Q, int accuracy)
        {
            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double decimalValue = 0;

            // Переводим число из системы P в десятичную
            string[] parts = number.Split('.');
            for (int i = 0; i < parts[0].Length; i++)
            {
                int digitValue = digits.IndexOf(parts[0][i]);
                decimalValue += digitValue * Math.Pow(P, parts[0].Length - 1 - i);
            }

            if (parts.Length > 1) // Обработка дробной части
            {
                for (int i = 0; i < parts[1].Length; i++)
                {
                    int digitValue = digits.IndexOf(parts[1][i]);
                    decimalValue += digitValue / Math.Pow(P, i + 1);
                }
            }

            // Переводим из десятичной в систему Q
            long integerPart = (long)decimalValue;
            double fractionalPart = decimalValue - integerPart;
            string result;
            if (integerPart == 0)
            {
                result = "0"; // Если целая часть равна нулю, результат будет "0"
            }
            else
            {
                result = ""; // Если целая часть не равна нулю, строка остаётся пустой
            }


            while (integerPart > 0)
            {
                result = digits[(int)(integerPart % Q)] + result;
                integerPart /= Q;
            }
            // Добавляет дробную часть к результату, если задана точность и дробная часть не равна нулю
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

            return result; // Вывод результата
        }
    }
}