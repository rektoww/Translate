using System;
using ClassLibraryTranslate;

namespace WinFormsTranslate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFAQ formFAQ = new FormFAQ();
            formFAQ.ShowDialog();
        }

        static bool IsValidNumberForBase(string input, int Base)
        {
            int startIndex = input.StartsWith("-") ? 1 : 0;
            
            for (int i = startIndex; i < input.Length; i++)
            {
                char c = input[i];
                int digitValue = 0;

                if (char.IsDigit(c))
                {
                    digitValue = c - '0';
                }
                else if (char.IsLetter(c))
                {
                    digitValue = char.ToUpper(c) - 'A' + 10;
                }
                else
                {
                    return false;
                }
                
                if (digitValue >= Base)
                {
                    return false;
                }
            }
            return true;
        }

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                if (NPtextInput.Text.Contains(","))
                {
                    throw new ArgumentException("Ошибка: \nРазделителем дробной \nи целой части должна \nявляться \nточка. \nПовторите попытку.");
                }
                if (Ptext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана система \nсчисления P. \nПовторите попытку.");
                }
                if (Convert.ToInt32(Ptext.Text) < 2 || Convert.ToInt32(Ptext.Text) > 36)
                {
                    throw new ArgumentException("Ошибка: \nЗначение системы \nсчисления P\nдолжно находиться \nв промежутке [2;36]. \nПовторите попытку.");
                }
                if (Qtext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана система \nсчисления Q. \nПовторите попытку.");
                }
                if (Convert.ToInt32(Qtext.Text) < 2 || Convert.ToInt32(Qtext.Text) > 36)
                {
                    throw new ArgumentException("Ошибка: \nЗначение системы \nсчисления Q\nдолжно находиться \nв промежутке [2;36]. \nПовторите попытку.");
                }
                if (NPtextInput.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задано число Np. \nПовторите попытку.");
                }
                if (Accurancytext.Text == "")
                {
                    throw new ArgumentException("Ошибка: \nНе задана точность. \nПовторите попытку.");
                }
                if (!int.TryParse(Ptext.Text, out int P)) 
                {
                    throw new ArgumentException("Ошибка: \nЗначение P должно \nбыть целым числом. \nПовторите попытку.");
                }
                if (!int.TryParse(Qtext.Text, out int Q))
                {
                    throw new ArgumentException("Ошибка: \nЗначение Q должно \nбыть целым числом. \nПовторите попытку.");
                }
                if (!int.TryParse(Accurancytext.Text, out int accuracy))
                {
                    throw new ArgumentException("Ошибка: \nЗначение точности должно быть \nцелым числом. \nПовторите попытку.");
                }
                if (!IsValidNumberForBase(NPtextInput.Text, Convert.ToInt32(Ptext.Text)))
                {
                    throw new ArgumentException($"Ошибка: \nЧисло {NPtextInput.Text} не существует \nв системе счисления {Ptext.Text}. \nПовторите попытку.");
                }

                string output = Translate.ConvertNumber(NPtextInput.Text, P, Q, accuracy);

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
                FormError formError = new FormError("Ошибка: \nНепредвиденная \nошибка. \nПовторите попытку.");
                formError.ShowDialog();
            }
        }
    }
}
