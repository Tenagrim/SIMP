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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    public partial class Form1 : Form
    {
        private Graphics main_graphics;
        private State state;
        private Tool tool;
        private Document document;
        private Pen pen;
        private Keyboard keyboard;
        private Point mouse_start_pos;
        private Point mouse_end_pos;
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

            document = new Document(new Point(main_viewport.Size.Width, main_viewport.Size.Height));
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
        #region toool selection
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
        #endregion
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
        private void SaveDocument(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, document);
            fs.Close();
        }
        private void LoadDocument(string filename)
        {
            Document res;
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            res = (Document)bf.Deserialize(fs);
            fs.Close();
            document = res;
            SyncUi();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) // Save file dialog
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                SaveDocument(filename);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) // Open file dialog
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                LoadDocument(filename);
                Display();
            }
        }
        private void SyncUi()
        {
            documentStructureViewer1.ClearPanel();
            document.SyncUi(documentStructureViewer1);
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
        //TODO: merge layers
        //TODO: split layers
        //TODO: rename folders/layers
        //TODO: Duplicate shapes
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

        private void button1_Click(object sender, EventArgs e)
        {
            documentStructureViewer1.ClearPanel();
        }

        private void cb_debug_CheckedChanged(object sender, EventArgs e)
        {
            p_debug_panel.Visible = cb_debug.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SyncUi();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            document.Projection.Phi = (hScrollBar1.Value - 450) / 100.0F;
            textBox1.Text = $"{document.Projection.Phi}";
            textBox2.Text = $"{hScrollBar1.Value}";
            Display();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            document.Projection.Thetha= (vScrollBar1.Value - 450) / 100.0F;
            //textBox1.Text = $"{document.Projection.Phi}";
            //textBox2.Text = $"{hScrollBar1.Value}";
            Display();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            document.Projection.Perspective = checkBox1.Checked;
                numericUpDown1.Visible = checkBox1.Checked;
            Display();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            document.Projection.Zc = (int)numericUpDown1.Value;
            Display();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0,false, 400)); //e
            points.Add(new Point(150,0 , false, 400)); // A
            points.Add(new Point(150,150 , false, 400)); // B
            points.Add(new Point(250,150 , false, 400)); // C
            points.Add(new Point(250,0 , false, 400));  // D
            points.Add(new Point(400,0 , false, 400));  // F
            points.Add(new Point(400,0 , false, 0));  // H
            points.Add(new Point(400,250 , false, 0));  // K
            points.Add(new Point(400,500 , false, 200));  // O
            points.Add(new Point(400,250 , false, 400));  // N
            points.Add(new Point(0, 250, false, 400)); //M
            points.Add(new Point(0, 250, false, 0)); //J
            points.Add(new Point(0, 500, false, 200)); //P
            points.Add(new Point(400, 500, false, 200));  // O
            points.Add(new Point(0, 500, false, 200)); //P
            points.Add(new Point(0, 250, false, 400)); //M
            points.Add(new Point(0, 0, false, 400)); //e
            points.Add(new Point(0, 0, false, 0)); //G
            points.Add(new Point(400, 0, false, 0));  // H
            points.Add(new Point(400, 250, false, 0));  // K

            document.AddShape(new Shape(points));


            points = new List<Point>();
            points.Add(new Point(0, 0, false, 0)); //G
            points.Add(new Point(0, 250, false, 0)); //G
            points.Add(new Point(400, 250, false, 0)); //G
            document.AddShape(new Shape(points));
            points = new List<Point>();
            points.Add(new Point(400, 0, false, 400)); //G
            points.Add(new Point(400, 250, false, 400)); //G
            document.AddShape(new Shape(points));

            Display();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            document.Projection.PosX = document.Projection.PosX + 30;
            Display();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            document.Projection.PosX = document.Projection.PosX - 30;
            Display();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            document.Projection.PosY = document.Projection.PosY + 30;
            Display();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            document.Projection.PosY = document.Projection.PosY - 30;
            Display();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            document.Projection.PosX = document.Projection.PosX + 30;
            Display();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            document.Projection.PosX = document.Projection.PosX - 30;
            Display();
        }
    }
}
