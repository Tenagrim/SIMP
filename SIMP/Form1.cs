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
using System.Windows.Input;

namespace SIMP
{
    enum State
    {
        idle,
        draw_shape,
        select_points,
        select_shapes,
        move
    }
    enum Tool
    {
        none,
        select,
        pointer,
        move,
        pen,
        line,
        shape,
        formula,
        scale,
        rotate
    }

    delegate void procedure();

    public partial class Form1 : Form
    {
        private Graphics main_graphics;
        private State state;
        private Tool tool;
        private Document document;
        private Pen pen;
        private Keyboard keyboard;

        //private List<Point> shape;

        private Point mouse_start_pos;
        private Point mouse_end_pos;

        private event procedure ToolChanged;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
            main_viewport.Image = new Bitmap(main_viewport.Width, main_viewport.Height);
            main_graphics = Graphics.FromImage(main_viewport.Image);
            state = State.idle;
            tool = Tool.none;
            //shape = new List<Point>();
            pen = new Pen(Color.White, 2.0F);
            keyboard = new Keyboard();

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

            //foreach (var p in shape)
             //   p.Draw(main_graphics);
            // if (lb_layers.SelectedIndex != -1)
            //    lb_layers.Items[lb_layers.SelectedIndex] = document.CurrentLayer.ToString();
        }

        public void Display()
        {
            Update_view();
            main_viewport.Refresh();
        }

        private void main_viewport_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    if (tool == Tool.line)
            //    {
            //        shape.Add(new Point(e.X, e.Y, true));
            //        if (shape.Count == 2)
            //        {
            //            Line l = new Line(shape[0], shape[1]);
            //            l.Unselect();
            //            document.AddShape(l);
            //            shape.Clear();
            //        }
            //    }
            //Display();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UpdateLayersPanel()
        {
            foreach (var e in document.Entities)
            {
                if (e is Layer)
                {
                    documentStructureViewer1.AddLayer(e.Name, e.ID);
                }
                else if (e is Folder)
                {
                    documentStructureViewer1.AddFolder(e.Name, e.ID);
                }
                documentStructureViewer1.SetCurrentEntity(document.CurrentEntity.ID);
            }
        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void DrawSelectRect(float x, float y, float width, float height)
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
            main_graphics.DrawRectangle(select_pen, x, y, width, height);
            select_pen.Dispose();
        }

        private void b_new_layer_Click(object sender, EventArgs e)
        {
            document.NewLayer();
            documentStructureViewer1.AddLayer(document.CurrentEntity.Name, document.CurrentEntity.ID);
            documentStructureViewer1.SetCurrentEntity(document.CurrentEntity.ID);
            Display();
        }
        private void b_new_folder_Click(object sender, EventArgs e)
        {
            document.NewFolder();
            documentStructureViewer1.AddFolder(document.LastAdded.Name, document.LastAdded.ID);
        }

        private void b_delete_selected_layers_Click(object sender, EventArgs e)
        {
            document.DeleteEntity(documentStructureViewer1.SelectedIds);
            documentStructureViewer1.DeleteSelected();
            Display();
        }
        private void UnselectTools()
        {
            if (document.TempPoints.Count != 0)
            {
                document.ClearTempVerticies();
                Display();
            }

            b_tool_select.Text = "Select _";
            b_tool_move.Text = "Move _";
            b_tool_line.Text = "Line _";
            button4.Text = "Formula _";
            b_tool_shape.Text = "Shape _";
            b_tool_pointer.Text = "Pointer _";
            button3.Text = "Scale _";
            button5.Text = "Rotate _";
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

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tool.formula;
            UnselectTools();
            button4.Text = "Formula ";
        }

        private void b_tool_shape_Click(object sender, EventArgs e)
        {
            UnselectTools();
            tool = Tool.shape;
            b_tool_shape.Text = "Shape ";
        }
        private void b_tool_pointer_Click(object sender, EventArgs e)
        {
            UnselectTools();
            tool = Tool.pointer;
            b_tool_pointer.Text = "Pointer ";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UnselectTools();
            tool = Tool.scale;
            button3.Text = "Scale ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnselectTools();
            tool = Tool.rotate;
            button5.Text = "Rotate ";
        }

        private void main_viewport_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == State.idle && tool == Tool.select)
            {
                if (!keyboard.IsKeyDown(17)) //CTRL
                    document.UnselectAll();
                mouse_start_pos = new Point(e.X, e.Y);
                state = radioButton1.Checked ? State.select_points : State.select_shapes;
            }
            else if (state == State.idle && tool == Tool.move)
            {
                mouse_start_pos = new Point(e.X, e.Y);
                state = State.move;
            }
            else if (state == State.idle && tool == Tool.formula)
            {
                mouse_start_pos = new Point(e.X, e.Y);
                Shape s = document.GetShape(mouse_start_pos);
                Line l = s == null ? null : s as Line;
                if (l != null)
                {
                    document.UnselectAll();
                    l.Select();
                    label1.Text = l.Formula;
                }
            }
            else if (tool == Tool.shape)
            {
                if (document.TempPoints.Count >= 3 && Point.Dist(document.TempPoints[0], new Point(e.X, e.Y)) <= 5)
                    document.AddShape(true);
                else
                    document.TempPoints.Add(new Point(e.X, e.Y, true));
                Display();
            }
            else if (tool == Tool.pointer)

            {
                if (!keyboard.IsKeyDown(17)) //CTRL
                    document.UnselectAll();
                state = radioButton1.Checked ? State.select_points : State.select_shapes;
                bool selecting = !keyboard.IsKeyDown(18); //ALT
                if (state == State.select_points)
                    document.SelectPoints(new Point(e.X, e.Y), selecting);
                else if (state == State.select_shapes)
                    document.SelectShapes(new Point(e.X, e.Y), selecting);
                Display();
                mouse_start_pos = new Point(e.X, e.Y);
                state = State.move;
            }
            else if (tool == Tool.line)
            {

                    document.TempPoints.Add(new Point(e.X, e.Y, true));
                if (document.TempPoints.Count >= 2)
                    document.AddLine();
                Display();
            }
        }

        private void main_viewport_MouseMove(object sender, MouseEventArgs e)
        {
            if (tool == Tool.select && (state == State.select_points || state == State.select_shapes))
            {
                Update_view();
                DrawSelectRect(mouse_start_pos.x, mouse_start_pos.y, e.X - mouse_start_pos.x, e.Y - mouse_start_pos.y);
                main_viewport.Refresh();
            }
            else if (state == State.move && (tool == Tool.move || tool == Tool.pointer))
            {
                int off_x;
                int off_y;
                for (int i = 0; i < document.SelectedPoints.Count; i++)
                {
                    off_x = e.X - (int)mouse_start_pos.x;
                    off_y = e.Y - (int)mouse_start_pos.y;

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
            if (tool == Tool.select)
            {
                mouse_end_pos = new Point(e.X, e.Y);
                bool selecting = !keyboard.IsKeyDown(18); //ALT
                if (state == State.select_points)
                    document.SelectPoints(mouse_start_pos, mouse_end_pos, selecting);
                else if (state == State.select_shapes)
                    document.SelectShapes(mouse_start_pos, mouse_end_pos, selecting);
                Display();
                state = State.idle;
            }
            else if (tool == Tool.pointer)
            {

                state = State.idle;
            }
            else if (state == State.move && (tool == Tool.move))
            {
                state = State.idle;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            document.UnselectAll();
            Display();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyboard.KeyDown(e.KeyValue);

            if (keyboard.IsKeysDown((int)(Keys.ControlKey), (int)Keys.D))
            {
                document.UnselectAll();
                Display();
            }
            if (keyboard.IsKeysDown((int)(Keys.ControlKey), (int)Keys.A))
            {
                document.SelectAll();
                Display();
            }


            if (e.KeyCode == Keys.Space && tool == Tool.shape)
            {
                document.AddShape();
                Display();
            }
            if (e.KeyCode == Keys.Delete)
            {
                document.DeleteSelected();
                Display();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyboard.KeyUp(e.KeyValue);
        }
        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            document.UnselectAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            document = new Document();
            Display();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            document.SelectAll();
            Display();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //points or shapes selection
        }
        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            document.DeleteSelected();
            Display();
        }
        private void SaveDocument()
        {
//TODO: Save
        }
        private void LoadDocument()
        {
//TODO:Load
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Display();
            document.center(main_graphics);
            main_viewport.Refresh();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case Tool.scale:
                    // mouse_start_pos = new Point(e.X, e.Y);
                    if (e.Delta > 0)
                        document.ScaleSelected(1.1F, 1.1F);
                    else
                        document.ScaleSelected(0.9F, 0.9F);
                    Display();
                    break;
                case Tool.rotate:
                    //mouse_start_pos = new Point(e.X, e.Y);
                    if (e.Delta > 0)
                        document.RotateSelected(0.1F);
                    else
                        document.RotateSelected(-0.1F);
                    Display();
                    break;
            }
        }
        private void documentStructureViewer1_OnSetCurrentEntity(object sender, WindowsFormsControlLibrary1.DocumentStructureArgs args)
        {
            document.SetCurrentEntity(args.CurrentEntityId);
        }
        private void ShowMsg(string msg)
        {
            MessageBox.Show(
             msg,
              "Info",
            MessageBoxButtons.OK,
      MessageBoxIcon.Information);
        }

        //TODO: delete layes/folders
        //TODO: merge layers
        //TODO: split layers
        private void documentStructureViewer1_OnVisibleChanged_(object sender, WindowsFormsControlLibrary1.DocumentStructureArgs args)
        {
            document.ChangeVisible(args.CurrentEntityId, args.flag);
            Display();
        }

        private void documentStructureViewer1_OnAddChilds(object sender, WindowsFormsControlLibrary1.DocumentStructureArgs args)
        {
            document.AddChilds(args.NewParent, args.SelectedIds);
            Display();
        }
        private void documentStructureViewer1_OnUnsetChilds(object sender, WindowsFormsControlLibrary1.DocumentStructureArgs args)
        {
            document.UnsetChilds(args.SelectedIds);
            Display();
        }
    }
}
