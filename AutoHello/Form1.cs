using System;
using Microsoft.Win32;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoHello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetAutoRunValue(true, Assembly.GetExecutingAssembly().Location);

            MessageBox.Show("It's AutoHello App", "Hello!",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private bool SetAutoRunValue(bool autorun, string path)
        {
            const string name = "AutoHello";

            string ExePath = path;

            RegistryKey reg;

            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

            try
            {
                if (autorun)
                {
                    reg.SetValue(name, ExePath);
                }
                else
                {
                    reg.DeleteValue(name);
                }

                reg.Flush();

                reg.Close();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
