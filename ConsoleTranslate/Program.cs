using System.Diagnostics;
using ClassLibraryTranslate;

Console.WriteLine("Тестирование конвертации чисел");
Test_NumberConversion();
Console.WriteLine("Нажмите любую клавишу для завершения...");
Console.ReadKey();

/// <summary>
/// Тестирование конвертации чисел между различными системами счисления
/// </summary>
static void Test_NumberConversion()
{
    // Тестовые случаи: [число, исходная система счисления, целевая система счисления, точность]
    var testCases = new[]
    {
        new { Number = "1234", P = 10, Q = 2, Accuracy = 0 },
        new { Number = "FF", P = 16, Q = 10, Accuracy = 0 },
        new { Number = "1010", P = 2, Q = 16, Accuracy = 0 },
        new { Number = "123.45", P = 10, Q = 8, Accuracy = 4 },
        new { Number = "A5", P = 16, Q = 8, Accuracy = 0 }
    };

    foreach (var test in testCases)
    {
        string result = Translate.ConvertNumber(test.Number, test.P, test.Q, test.Accuracy);
        Console.WriteLine($"Тест конвертации:");
        Console.WriteLine($"Исходное число: {test.Number} (система счисления {test.P})");
        Console.WriteLine($"Результат: {result} (система счисления {test.Q})");
        Console.WriteLine($"Точность: {test.Accuracy} знаков после запятой");
        Console.WriteLine("----------------------------------------");

        // Проверка корректности конвертации путем обратного преобразования
        if (!test.Number.Contains("."))  // Только для целых чисел
        {
            string backConversion = Translate.ConvertNumber(result, test.Q, test.P, 0);
            Debug.Assert(backConversion.Equals(test.Number, StringComparison.OrdinalIgnoreCase), 
                $"Ошибка в обратной конвертации: {test.Number} -> {result} -> {backConversion}");
        }
    }
    
    Console.WriteLine("Все тесты успешно пройдены!");
}
