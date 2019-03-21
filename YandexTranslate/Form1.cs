using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YandexTranslate
{
    public partial class Form1 : Form
    {
        ComboBox cb;

        BTranslator bt;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedItem = "Русский";

            comboBox2.SelectedItem = "Английский";

            cb = new ComboBox();

            bt = new BTranslator();

            #region Коллекция языков переводчика

            cb.Items.AddRange(new object[] {
                                                    "Азербайджанский",
                                                    "Албанский",
                                                    "Английский",
                                                    "Армянский",
                                                    "Белорусский",
                                                    "Болгарский",
                                                    "Венгерский",
                                                    "Голландский",
                                                    "Греческий",
                                                    "Датский",
                                                    "Испанский",
                                                    "Итальянский",
                                                    "Каталанский",
                                                    "Латышский",
                                                    "Литовский",
                                                    "Македонский",
                                                    "Немецкий",
                                                    "Норвежский",
                                                    "Польский",
                                                    "Португальский",
                                                    "Румынский",
                                                    "Русский",
                                                    "Сербский",
                                                    "Словацкий",
                                                    "Словенский",
                                                    "Турецкий",
                                                    "Украинский",
                                                    "Финский",
                                                    "Французский",
                                                    "Хорватский",
                                                    "Чешский",
                                                    "Шведский",
                                                    "Эстонский"});
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Русский";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Английский";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Немецкий";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Французский";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cb.SelectedItem = comboBox1.SelectedItem;

            comboBox1.SelectedItem = comboBox2.SelectedItem;

            comboBox2.SelectedItem = cb.SelectedItem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Clear();

                richTextBox2.Text = bt.Translator(richTextBox1.Text, bt.GetLangPair(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString()));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YandexTranslator v1.0.1\nПереведено сервисом «Яндекс.Переводчик»\n http://translate.yandex.ru/","О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(sender, e);
            }
        }
    }
}
