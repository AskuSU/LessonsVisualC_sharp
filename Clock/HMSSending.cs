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
    delegate void SendTimeDel(string t);

    public partial class Form1 : Form
    {
        SendTimeDel sT;

        DateTime dT;

        HMS hMS;

        private void CountSeconds()
        {
            sT = new SendTimeDel(SendSeconds);

            while (true)
            {
                dT = DateTime.Now;

                hMS = new HMS(dT);

                SendSeconds($"{hMS.H}:{hMS.M}:{hMS.S}");

                Thread.Sleep(1000);
            }
        }

        public void SendSeconds(string text)
        {
            if (label1.InvokeRequired)
            {
                Invoke(sT, new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }
    }
}
