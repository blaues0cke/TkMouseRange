using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using gma.System.Windows;

namespace TkMouseRange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UserActivityHook actHook;
        private void Form1_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook();
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);


        }



        public void MouseMoved(object sender, MouseEventArgs e)
        {
            using (Bitmap Screen = new Bitmap(trackBar1.Value, trackBar1.Value))
            {
                using (Graphics g = Graphics.FromImage(Screen))
                {
                    g.CopyFromScreen(e.X - trackBar1.Value / 2, e.Y - trackBar1.Value / 2, 0, 0, new Size(trackBar1.Value, trackBar1.Value));
                 }
                 pictureBox1.Image = new Bitmap(Screen);
            }





        }

    }
}
