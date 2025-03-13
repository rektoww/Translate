using System;
using ClassLibraryTranslate;

    /// <summary>
    /// Тестирует метод ConvertIntegerPart, который преобразует целую часть числа из заданной системы счисления в десятичную
    /// </summary>
    static void TestConvertIntegerPart()
    {
        Console.WriteLine("Тестирование ConvertIntegerPart:");
        // Тест преобразования числа из десятичной системы
        double decimalValue = 0;
        Translate.ConvertIntegerPart("123", 10, "0123456789", ref decimalValue);
        Console.WriteLine($"123 (10) -> {decimalValue} (10)");
        
        // Тест преобразования числа из шестнадцатеричной системы
        decimalValue = 0;
        Translate.ConvertIntegerPart("FF", 16, "0123456789ABCDEF", ref decimalValue);
        Console.WriteLine($"FF (16) -> {decimalValue} (10)");
    }
    TestConvertIntegerPart();

    /// <summary>
    /// Тестирует метод ConvertFractionalPart, который преобразует дробную часть числа из заданной системы счисления в десятичную
    /// </summary>
    static void TestConvertFractionalPart()
    {
        Console.WriteLine("\nТестирование ConvertFractionalPart:");
        // Тест преобразования дробной части из десятичной системы
        double decimalValue = 0;
        Translate.ConvertFractionalPart("5", 10, "0123456789", ref decimalValue);
        Console.WriteLine($"0.5 (10) -> {decimalValue} (10)");
        
        // Тест преобразования дробной части из шестнадцатеричной системы
        decimalValue = 0;
        Translate.ConvertFractionalPart("8", 16, "0123456789ABCDEF", ref decimalValue);
        Console.WriteLine($"0.8 (16) -> {decimalValue} (10)");
    }
    TestConvertFractionalPart();    
    /// <summary>
    /// Тестирует метод ConvertFromDecimalToBaseQInteger, который преобразует целое десятичное число в число в заданной системе счисления
    /// </summary>
    static void TestConvertFromDecimalToBaseQInteger()
    {
        Console.WriteLine("\nТестирование ConvertFromDecimalToBaseQInteger:");
        // Преобразование из десятичной в шестнадцатеричную систему
        string result = Translate.ConvertFromDecimalToBaseQInteger(255, 16, "0123456789ABCDEF");
        Console.WriteLine($"255 (10) -> {result} (16)");
        
        // Проверка работы с десятичной системой (преобразование в ту же систему)
        result = Translate.ConvertFromDecimalToBaseQInteger(123, 10, "0123456789");
        Console.WriteLine($"123 (10) -> {result} (10)");
    }
    TestConvertFromDecimalToBaseQInteger();
    /// <summary>
    /// Тестирует метод ConvertFromDecimalToBaseQFractional, который преобразует дробную часть десятичного числа в число в заданной системе счисления
    /// </summary>
static void TestConvertFromDecimalToBaseQFractional()
    {
        Console.WriteLine("\nТестирование ConvertFromDecimalToBaseQFractional:");
        // Преобразование 0.5 в шестнадцатеричную систему с точностью 4 знака
        string result = "";
        Translate.ConvertFromDecimalToBaseQFractional(ref result, 0.5, 16, 4, "0123456789ABCDEF");
        Console.WriteLine($"0.5 (10) -> 0.{result} (16)");
        
        // Преобразование 0.75 в двоичную систему с точностью 4 знака
        result = "";
        Translate.ConvertFromDecimalToBaseQFractional(ref result, 0.75, 2, 4, "01");
        Console.WriteLine($"0.75 (10) -> 0.{result} (2)");
    }
    TestConvertFromDecimalToBaseQFractional();

    /// <summary>
    /// Тестирует метод ConvertFromDecimalToBaseQ, который преобразует десятичное число в число в заданной системе счисления
    /// </summary>
static void TestConvertFromDecimalToBaseQ()
    {
        Console.WriteLine("\nТестирование ConvertFromDecimalToBaseQ:");
        // Преобразование десятичного числа в шестнадцатеричную систему с точностью 4 знака
        string result = Translate.ConvertFromDecimalToBaseQ(123.456, 16, 4, "0123456789ABCDEF");
        Console.WriteLine($"123.456 (10) -> {result} (16)");
        
        // Преобразование десятичного числа в двоичную систему с точностью 4 знака
        result = Translate.ConvertFromDecimalToBaseQ(0.75, 2, 4, "01");
        Console.WriteLine($"0.75 (10) -> {result} (2)");
    }
    TestConvertFromDecimalToBaseQ();
    /// <summary>
    /// Тестирует метод SplitDecimalValue, который разделяет десятичное число на целую и дробную части
    /// </summary>
static void TestSplitDecimalValue()
    {
        Console.WriteLine("\nТестирование SplitDecimalValue:");
        // Разделение десятичного числа на целую и дробную части
        Translate.SplitDecimalValue(123.456, out long integerPart, out double fractionalPart);
        Console.WriteLine($"123.456 -> Целая часть: {integerPart}, Дробная часть: {fractionalPart}");
    }
    TestSplitDecimalValue();
    /// <summary>
    /// Тестирует метод SplitNumber, который разделяет строковое представление числа на целую и дробную части
    /// </summary>
static void TestSplitNumber()
    {
        Console.WriteLine("\nТестирование SplitNumber:");
        // Тест разделения числа, содержащего дробную часть
        string[] parts = Translate.SplitNumber("123.456");
        Console.WriteLine($"123.456 -> Целая часть: {parts[0]}, Дробная часть: {parts[1]}");
        
        // Тест разделения целого числа (без дробной части)
        parts = Translate.SplitNumber("123");
        Console.WriteLine($"123 -> Целая часть: {parts[0]}");
    }
    TestSplitNumber();
    /// <summary>
    /// Тестирует метод ConvertNumber, который преобразует число из одной системы счисления в другую
    /// </summary>
static void TestConvertNumber()
    {
        Console.WriteLine("\nТестирование ConvertNumber:");
        // Преобразование шестнадцатеричного числа в десятичное
        string result = Translate.ConvertNumber("FF", 16, 10, 0);
        Console.WriteLine($"FF (16) -> {result} (10)");
        
        // Преобразование десятичного числа в шестнадцатеричное с точностью 4 знака после запятой
        result = Translate.ConvertNumber("123.456", 10, 16, 4);
        Console.WriteLine($"123.456 (10) -> {result} (16)");
    }
    TestConvertNumber();
    /// <summary>
    /// Тестирует метод IsNegativeNumber, который проверяет, является ли число отрицательным
    /// </summary>
static void TestIsNegativeNumber()
    {
        Console.WriteLine("\nТестирование IsNegativeNumber:");
        // Тест с отрицательным числом
        string negativeNumber = "-123";
        bool isNegative = Translate.IsNegativeNumber(ref negativeNumber);
        Console.WriteLine($"Число {negativeNumber} отрицательное: {isNegative}");
        
        // Тест с положительным числом
        string positiveNumber = "123";
        isNegative = Translate.IsNegativeNumber(ref positiveNumber);
        Console.WriteLine($"Число {positiveNumber} отрицательное: {isNegative}");
    }
    TestIsNegativeNumber();