using System;
using ClassLibraryTranslate;

using System;
using ClassLibraryTranslate;

namespace WinFormsTranslate
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Конструктор главной формы.
        /// Инициализирует все элементы интерфейса.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Закрывает приложение при нажатии кнопки "Выход".
        /// </summary>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Завершаем работу приложения
        }

        /// <summary>
        /// Открывает окно "Часто задаваемые вопросы" (FAQ).
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            FormFAQ formFAQ = new FormFAQ(); // Создаём объект формы FAQ
            formFAQ.ShowDialog(); // Показываем его пользователю в модальном режиме
        }

        /// <summary>
        /// Проверяет, является ли строка корректным числом в указанной системе счисления.
        /// </summary>
        /// <param name="input">Строка с числом.</param>
        /// <param name="Base">Основание системы счисления.</param>
        /// <returns>True, если число корректное, иначе False.</returns>
        static bool IsValidNumberForBase(string input, int Base)
        {
            // Определяем, начинается ли число с отрицательного знака
            int startIndex = input.StartsWith("-") ? 1 : 0;
            bool point = false;

            // Проверяем каждый символ в числе
            for (int i = startIndex; i < input.Length; i++)
            {
                char c = input[i];

                // Разрешаем только точку в качестве десятичного разделителя
                if (c == '.')
                {
                    if (point)
                    {
                        return false; // Если точка уже была, значит возвращаем false - ошибка
                    }
                    point = true;
                    continue;
                }

                int digitValue = 0;
                if (char.IsDigit(c))
                {
                    digitValue = c - '0'; // Преобразуем символ в число (0-9)
                }
                else if (char.IsLetter(c))
                {
                    digitValue = char.ToUpper(c) - 'A' + 10; // Преобразуем букву в число (A = 10, B = 11 и т.д.)
                }
                else
                {
                    return false; // Если встречен недопустимый символ, число невалидно
                }

                if (digitValue >= Base)
                {
                    return false; // Если цифра превышает допустимое значение, число некорректное
                }
            }
            return true; // Число корректное
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "Рассчитать" и выполняет перевод числа из одной системы счисления в другую.
        /// </summary>
        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на существование значения P
                if (Ptext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе указано \nзначение P. \nПовторите попытку.");
                }
                // Проверка, является ли P целым числом
                if (!int.TryParse(Ptext.Text, out int P))
                {
                    throw new ArgumentException("Ошибка: \nЗначение P должно \nбыть целым числом. \nПовторите попытку.");
                }
                // Проверка на существование значения Q
                if (Qtext.Text== "")
                {
                    throw new ArgumentException("Ошибка: \nНе указано \nзначение Q. \nПовторите попытку.");
                }
                // Проверка, является ли Q целым числом
                if (!int.TryParse(Qtext.Text, out int Q))
                {
                    throw new ArgumentException("Ошибка: \nЗначение Q должно \nбыть целым числом. \nПовторите попытку.");
                }

                // Проверка диапазона системы счисления P (должно быть от 2 до 36)
                if (P < 2 || P > 36)
                {
                    throw new ArgumentException("Ошибка: \nЗначение системы \nсчисления P\nдолжно находиться \nв промежутке [2;36]. \nПовторите попытку.");
                }

                // Проверка диапазона системы счисления Q (должно быть от 2 до 36)
                if (Q < 2 || Q > 36)
                {
                    throw new ArgumentException("Ошибка: \nЗначение системы \nсчисления Q\nдолжно находиться \nв промежутке [2;36]. \nПовторите попытку.");
                }
                // Проверка на существование исходного числа
                if (NPtextInput.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе указано исходное \nчисло. \nПовторите попытку.");
                }
                // Проверка на существование точности
                if (Accurancytext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе указано значение \nточности. \nПовторите попытку.");
                }
                // Проверка, является ли точность целым числом
                if (!int.TryParse(Accurancytext.Text, out int accuracy))
                {
                    throw new ArgumentException("Ошибка: \nЗначение точности \nдолжно быть целым \nчислом. \nПовторите попытку.");
                }
                // Проверка на использование запятой вместо точки
                if (NPtextInput.Text.Contains(","))
                {
                    throw new ArgumentException("Ошибка: \nРазделителем дробной \nи целой части должна \nявляться \nточка. \nПовторите попытку.");
                }

                // Проверка, заполнены ли все необходимые поля
                if (Ptext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана система \nсчисления P. \nПовторите попытку.");
                }
                // Проверка, задана ли система счисления Q
                if (Qtext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана система \nсчисления Q. \nПовторите попытку.");
                }
                // Проверка, задано ли число Np
                if (NPtextInput.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задано число Np. \nПовторите попытку.");
                }
                // Проверка, задана ли точность
                if (Accurancytext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана точность. \nПовторите попытку.");
                }

                // Проверка, является ли введённое число допустимым в системе счисления P
                if (!IsValidNumberForBase(NPtextInput.Text, Convert.ToInt32(Ptext.Text)))
                {
                    throw new ArgumentException($"Ошибка: \nЧисло {NPtextInput.Text} \nне существует \nв системе счисления {Ptext.Text}. \nПовторите попытку.");
                }

                // Выполняем конвертацию числа, используя библиотеку ClassLibraryTranslate
                string output = Translate.ConvertNumber(NPtextInput.Text, P, Q, accuracy);

                // Выводим результат в текстовое поле
                NQtextOutput.Text = output;
            }
            catch (ArgumentException ex)
            {
                // Открываем форму Error для отображения ошибки
                FormError errorForm = new FormError(ex.Message);
                errorForm.ShowDialog();
            }
            catch (Exception)
            {
                // Обрабатываем любые непредвиденные ошибки
                FormError formError = new FormError("Ошибка: \nНепредвиденная \nошибка. \nПовторите попытку.");
                formError.ShowDialog();
            }
        }
    }
}
