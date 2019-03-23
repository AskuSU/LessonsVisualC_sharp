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
    delegate void SendDateDel(string t);

    public partial class Form1 : Form
    {

        SendDateDel sD;

        YMD yMD;

        private void CountDays()
        {
            sD = new SendDateDel(SendDeys);

            while (true)
            {
                dT = DateTime.Now;

                yMD = new YMD(dT);

                SendDeys($"{yMD.D}.{yMD.M}.{yMD.Y}");

                Thread.Sleep(1000);
            }
        }

        public void SendDeys(string text)
        {
            if (label2.InvokeRequired)
            {
                Invoke(sD, new object[] { text });
            }
            else
            {
                label2.Text = text;
            }
        }
    }
}
