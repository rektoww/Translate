﻿namespace WinFormsTranslate
{
    partial class FormError
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 207, 171);
            button1.Font = new Font("Montserrat SemiBold", 17.9999981F, FontStyle.Bold | FontStyle.Italic);
            button1.ForeColor = Color.FromArgb(178, 118, 252);
            button1.Location = new Point(162, 276);
            button1.Name = "button1";
            button1.Size = new Size(110, 41);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Montserrat Black", 21.7499962F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(178, 118, 252);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(109, 45);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // FormError
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormErrorImageBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(437, 329);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormError";
            Text = "Error";
            Load += FormError_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
    }
}