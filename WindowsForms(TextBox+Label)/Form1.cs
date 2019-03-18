using System;

using System.Windows.Forms;

namespace WindowsForms_TextBox_Label_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Текст: ";

                if (textBox1.Text != "")
                {
                    label1.Text += textBox1.Text;
                }
                
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Текст: ";
            }
            catch (Exception)
            {

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Текст: ";

                if (textBox1.Text != "")
                {
                    label1.Text += textBox1.Text;
                }

            }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
            }
            catch (Exception)
            {

            }
        }
    }
}
