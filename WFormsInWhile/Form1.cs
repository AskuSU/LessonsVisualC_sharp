using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WFormsInWhile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            
            while (true)
            {
                ThreadPool.QueueUserWorkItem(state => 
                {
                    MessageForm msf = new MessageForm($"Форма №{i}", $"Это форма №{i}");

                    Application.Run(msf);
                });

                i++;

                Thread.Sleep(5000);
            }
        }
    }
}
