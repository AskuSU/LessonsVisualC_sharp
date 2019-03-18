using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }
    }
}
