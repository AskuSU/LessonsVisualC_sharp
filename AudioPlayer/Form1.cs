using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace AudioPlayer
{
    public partial class Form1 : Form
    {
        SoundPlayer player = null;

        string fileName = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                player.SoundLocation = fileName;

                player.Play();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error );

                OpenMedia();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMedia();
        }

        private void OpenMedia()
        {
            OpenFileDialog oFD = new OpenFileDialog()
            {
                Filter = "WAV|*.wav|Все файлы|*",

                Multiselect = false,

                ValidateNames = true
            };

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                fileName = oFD.FileName;

                textBox1.Text = fileName;
            }
        }
    }
}
