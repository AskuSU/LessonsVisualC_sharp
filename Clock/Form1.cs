using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {

        Thread secondsCountingThread;

        Thread daysCountingThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            secondsCountingThread = new Thread( new ThreadStart(CountSeconds));

            secondsCountingThread.Start();

            daysCountingThread = new Thread(new ThreadStart(CountDays));

            daysCountingThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            secondsCountingThread.Abort();

            daysCountingThread.Abort();
        }
    }
}
