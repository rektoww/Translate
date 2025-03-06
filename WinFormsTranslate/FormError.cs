using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTranslate
{
    /// <summary>
    /// 
    /// Форма Error демонстрации ошибки
    /// 
    /// </summary>
    public partial class FormError : Form
    {
        /// <summary>
        /// 
        /// форма с текстом ошибки
        /// 
        /// </summary>
        /// <param name="message"></param>
        public FormError(string message)
        {
            InitializeComponent(); // Инициализация компонентов формы

            label1.Text = message; // Установка переданного сообщения в label
        }

        /// <summary>
        /// 
        /// кнопка, закрывает
        /// окно ошибки
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы
        }

        private void FormError_Load(object sender, EventArgs e)
        {

        }
    }
}

