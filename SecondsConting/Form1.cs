using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SecondsConting
{
    delegate void SendSecondsDel(string t);

    public partial class Form1 : Form
    {
        SendSecondsDel sD;

        Thread countingThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void CountSecons()
        {
            int i= 0;

            sD = new SendSecondsDel(SendSeconds);

            while (true)
            {
                i++;

                SendSeconds(i.ToString());

                Thread.Sleep(1000);

                if (i == 60)
                {
                    i = 0;
                }
            }
        }

        private void SendSeconds(string text)
        {
            if (label1.InvokeRequired)
            {
                Invoke(sD, new object[] { text });
            }
            else
            {
                label1.Text = text;
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            countingThread = new Thread(new ThreadStart(CountSecons));

            countingThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            countingThread.Abort();
        }
    }
}
