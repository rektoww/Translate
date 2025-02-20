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

        private void ButtonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                int P = int.Parse(Ptext.Text);
                int Q = int.Parse(Qtext.Text);
                int accuracy = int.Parse(Accurancytext.Text);

                string output = Translate.ConvertNumber(NPtextInput.Text, P, Q, accuracy);

                NQtextOutput.Text = output;
            }
            catch (Exception)
            {
                FormError formError = new FormError("Здесь будет \nсообщение об ошибке.");
                formError.ShowDialog();
            }
        }
    }
}
