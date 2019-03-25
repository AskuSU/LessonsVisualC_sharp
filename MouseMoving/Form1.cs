using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MouseMoving
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MoveMouse(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
        }


        private void MoveMouse(int screenWidth, int screenHeight)
        {
            POINT p = new POINT();

            Random r = new Random();

            int c = 0;

            while (true)
            {
                p.x = Convert.ToInt16(r.Next(screenWidth));

                p.y = Convert.ToInt16(r.Next(screenHeight));

                ClientToScreen(Handle, ref p);

                SetCursorPos(p.x, p.y);

                c++;

                Thread.Sleep(200);

                if (c == 50)
                {
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hMnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;

            public int y;
        }
    }
}
