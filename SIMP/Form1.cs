using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMP
{
    enum State
    {
        idle,
        draw_shape,
        move
    }
    enum Tool
    {
        none,
        select,
        move,
        pen,
        line,
        shape
    }
    public partial class Form1 : Form
    {
        private Graphics main_graphics;
        private State state;
        private Tool tool;
        private Document document;
        private Pen pen;

        private List<Point> shape;

        private Point mouse_start_pos;
        private Point mouse_end_pos;

        public Form1()
        {
            InitializeComponent();
            main_viewport.Image = new Bitmap(main_viewport.Width, main_viewport.Height);
            main_graphics = Graphics.FromImage(main_viewport.Image);
            state = State.idle;
            tool = Tool.none;
            shape = new List<Point>();
            pen = new Pen(Color.White, 2.0F);

            document = new Document();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateLayersPanel();
            Display();
        }

        public void Update_view()
        {
            main_graphics.Clear(Color.Black);
            document.Display(main_graphics, pen);

            foreach (var p in shape)
                p.Draw(main_graphics);
            if (lb_layers.SelectedIndex != -1)
                lb_layers.Items[lb_layers.SelectedIndex] = document.CurrentLayer.ToString();
        }

        public void Display()
        {
            Update_view();
            main_viewport.Refresh();
        }

        private void main_viewport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (tool == Tool.line)
                {
                    shape.Add(new Point(e.X, e.Y, true));
                    if (shape.Count == 2)
                    {
                        Line l = new Line(shape[0], shape[1]);
                        l.Unselect();
                        document.CurrentLayer.AddShape(l);
                        shape.Clear();
                    }
                }
            Display();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UpdateLayersPanel()
        {
            lb_layers.Items.Clear();
            foreach (var l in document.Layers)
                lb_layers.Items.Add(l.ToString());
            lb_layers.SelectedIndex = document.CurrentLayerIndex;

        }

        private void cb_layer_visible_CheckedChanged(object sender, EventArgs e)
        {
            document.CurrentLayer.Visible = cb_layer_visible.Checked;
            lb_layers.Items[lb_layers.SelectedIndex] = document.CurrentLayer.ToString();
            Display();
        }

        private void lb_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            document.SetCurrentLayer(lb_layers.SelectedIndex);
            cb_layer_visible.Checked = document.CurrentLayer.Visible;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (shape.Count != 0 && tool == Tool.shape)
                    {
                        document.CurrentLayer.AddShape(new Shape(shape));
                        shape.Clear();
                    }
                    Display();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DrawSelectRect(int x, int y, int width, int height)
        {
            Pen select_pen = new Pen(Color.White, 1.0F);
            select_pen.DashStyle = DashStyle.Dot;
            if (width < 0)
            {
                width = -width;
                x -= width;
            }
            if (height < 0)
            {
                height = -height;
                y -= height;
            }
            main_graphics.DrawRectangle(select_pen, x, y, width , height );
            select_pen.Dispose();
        }

        private void b_new_layer_Click(object sender, EventArgs e)
        {
            document.NewLayer();
            lb_layers.Items.Add(document.Layers.Last());
            lb_layers.SelectedIndex = lb_layers.Items.Count - 1;
        }

        private void UnselectTools()
        {
            b_tool_select.Text = "Select _";
            b_tool_move.Text = "Move _";
            b_tool_line.Text = "Line _";
        }

        private void b_tool_select_Click(object sender, EventArgs e)
        {
            tool = Tool.select;
            UnselectTools();
            b_tool_select.Text = "Select ";
        }

        private void b_tool_move_Click(object sender, EventArgs e)
        {
            tool = Tool.move;
            UnselectTools();
            b_tool_move.Text = "Move ";
        }

        private void b_tool_line_Click(object sender, EventArgs e)
        {
            tool = Tool.line;
            UnselectTools();
            b_tool_line.Text = "Line ";
        }

        private void main_viewport_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == State.idle && tool == Tool.select)
            {
                mouse_start_pos = new Point(e.X, e.Y);
                state = State.draw_shape;
            }
            else if (state == State.idle && tool == Tool.move)
            {
                mouse_start_pos = new Point(e.X, e.Y);
                state = State.move;
            }
        }

        private void main_viewport_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == State.draw_shape && tool == Tool.select)
            {
                Update_view();
                DrawSelectRect(mouse_start_pos.x, mouse_start_pos.y, e.X - mouse_start_pos.x, e.Y - mouse_start_pos.y);
                main_viewport.Refresh();
            }
            else if (state == State.move && tool == Tool.move)
            {
                int off_x;
                int off_y;
                for (int i = 0; i < document.SelectedPoints.Count; i++)
                {
                    off_x = e.X - mouse_start_pos.x;
                    off_y = e.Y - mouse_start_pos.y;

                    document.SelectedPoints[i].x = document.SelectedPoints[i].x + off_x;
                    document.SelectedPoints[i].y = document.SelectedPoints[i].y + off_y;
                }
                mouse_start_pos.x = e.X;
                mouse_start_pos.y = e.Y;
                Display();
            }
            else
            {

            }
        }

        private void main_viewport_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == State.draw_shape && tool == Tool.select)
            {
                mouse_end_pos = new Point(e.X, e.Y);
                document.SelectPoints(mouse_start_pos, mouse_end_pos);
                Display();
                state = State.idle;
            }
            else if (state == State.move && tool == Tool.move)
            {
                state = State.idle;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            document.UnselectAll();
            Display();
        }
    }
}
