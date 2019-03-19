using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuget
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();

            this.StyleManager = metroStyleManager1;
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked)
            {

                metroTabControl1.Visible = false;

                metroComboBox1.Visible = false;

                metroButton1.Visible = false;

                metroCheckBox1.Visible = false;
            }
            else
            {
                metroTabControl1.Visible = true;

                metroComboBox1.Visible = true;

                metroButton1.Visible = true;

                metroCheckBox1.Visible = true;
            }
        }
    }
}
