using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SalaryPro
{
    public partial class LinkerForm : Form
    {
        public LinkerForm()
        {
            InitializeComponent();
            this.Text = "Нумерація для Telegram";
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Регулярний вираз для пошуку посилань
            string pattern = @"https?://[^\s/$.?#].[^\s<>""]+";

            // rtbInput — це твоє поле RichTextBox на формі
            var matches = Regex.Matches(rtbInput.Text, pattern);

            if (matches.Count > 0)
            {
                // Перетворюємо знайдені посилання у нумерований список
                var list = matches.Cast<Match>()
                                  .Select((m, i) => $"{i + 1}. {m.Value}")
                                  .ToList();

                // Об'єднуємо список у один рядок з переносами та кидаємо в буфер (Ctrl+V)
                Clipboard.SetText(string.Join(Environment.NewLine, list));

                // Зворотний зв'язок для Світлани
                MessageBox.Show($"Готово! {matches.Count} лінків скопійовано у буфер.", "SalaryPro Linker");

                // Закриваємо вікно, щоб воно не висіло перед очима
                this.Close();
            }
            else
            {
                MessageBox.Show("У вставленому тексті не знайдено жодного посилання!", "Помилка");
            }
        }
    }
}