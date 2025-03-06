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
    /// Форма FAQ для отображения часто задаваемых вопросов
    /// 
    /// </summary>
    public partial class FormFAQ : Form
    {
        /// <summary>
        /// 
        /// Конструктор формы FAQ
        /// 
        /// </summary>
        public FormFAQ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// Закрывает окно FAQ при нажатии кнопки
        /// 
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

