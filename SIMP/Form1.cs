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
    enum State
    {
        idle,
        draw_shape
    }
    enum Tool
    {
        select,
        move,
        pen
    }
    public partial class Form1 : Form
    {
        private Graphics main_graphics;
        private State state;
        private Tool tool;
        private Document document;
        private Pen pen;

        private List<Point> shape;

        public Form1()
        {
            InitializeComponent();
            main_viewport.Image = new Bitmap(main_viewport.Width, main_viewport.Height);
            main_graphics = Graphics.FromImage(main_viewport.Image);
            state = State.idle;
            shape = new List<Point>();
            pen = new Pen(Color.White, 2.0F);

            document = new Document();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        public void Display()
        {
            main_graphics.Clear(Color.Black);
            document.Display(main_graphics, pen);

            foreach (var p in shape)
                p.Display(main_graphics);

            main_viewport.Refresh();
        }

        private void main_viewport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                shape.Add(new Point(e.X, e.Y));
            Display();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && shape.Count != 0)
            {
                document.CurrentLayer.AddShape(new Line(shape[0], shape[1]));
                shape.Clear();
            }
            Display();
        }
    }
}
