using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMP
{
    public partial class Form1 : Form
    {
        private Graphics main_graphics;

        public Form1()
        {
            main_viewport.Image = new Bitmap(main_viewport.Width, main_viewport.Height);
            main_graphics = Graphics.FromImage(main_viewport.Image);
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
