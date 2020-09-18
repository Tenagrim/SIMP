using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class DocumentStructureViewer : UserControl
    {
        public delegate void DocumentStructureHandler(object sender, DocumentStructureArgs args);

        //[EditorBrowsable(EditorBrowsableState.Always)]

        [Browsable(true), Category("Action")]
        [Description("Invoked when new current entity was set")]
        public event DocumentStructureHandler SetCurrentEntity;

        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler MakeChilds;

        public List<Panel> SelectedPanels { get { return (from p in panels where p.IsSelected select p).ToList(); } }
        public Panel CurrentEntity { get { return currentEntity; } }

        private Panel currentEntity;
        private List<Panel> panels;
        private int off_x = 2;
        private int off_y = 3;
        private int panel_height = 43;
        private int panel_width = 211;

        private Point mouse_start_pos;
        private Point mouse_end_pos;
        public DocumentStructureViewer()
        {
            InitializeComponent();
            panels = new List<Panel>();
            panel1.AutoScroll = false;

            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
        }

        private void DisplayFolder(FolderPanel folder, ref int pos)
        {
            folder.Location = new Point(off_x, off_y + pos * panel_height + panel1.AutoScrollPosition.Y);
            pos++;
            if (folder.IsOpened)
            {
                foreach (var p in folder.Childs)
                    if (p is FolderPanel)
                    {
                        p.Visible = true;
                        DisplayFolder((FolderPanel)p, ref pos);
                    }
                foreach (var l in folder.Childs)
                    if (l is LayerPanel)
                    {
                        l.Location = new Point(off_x, off_y + pos++ * panel_height + panel1.AutoScrollPosition.Y);
                        l.Visible = true;
                    }
            }
            else
                folder.HideChilds();
        }

        public void UpdateList()
        {
            int pos = 0;

            foreach (var p in panels)
                if (p is FolderPanel && p.Parent == null)
                DisplayFolder((FolderPanel)p, ref pos);
            foreach (var l in panels)
                if (l is LayerPanel && l.Parent == null)
                l.Location = new Point(off_x, off_y + pos++ * panel_height + panel1.AutoScrollPosition.Y);
        }

        private int CountFolders()
        {
            var res = (from p in panels
                       where p is FolderPanel
                       select p).Count();
            return res;
        }
        private int CountLayers()
        {
            var res = (from p in panels
                       where p is LayerPanel
                       select p).Count();
            return res;
        }

        public void AddFolder(string name, int id)
        {

            FolderPanel fp = new FolderPanel(name,this, id );
            //fp.Location = new System.Drawing.Point(off_x, folders.Count * panel_height + panel1.AutoScrollPosition.Y);
            //foreach(var l in layers)
            //    l.Location = new System.Drawing.Point(off_x, (folders.Count + layers.IndexOf(l)) * panel_height + panel1.AutoScrollPosition.Y);

            panels.Add(fp);
            UpdateList();           
            panel1.Controls.Add(fp);

            //vScrollBar1.Maximum = (layers.Count + folders.Count) * panel_height < panel1.Height? 0 : (layers.Count + folders.Count) * panel_height - panel1.Height;
        }

        public void AddLayer(string name, int id)
        {
            string str = $"Layer {CountLayers() + 1}";

            LayerPanel fp = new LayerPanel(str,this, panels.Count());
            //fp.Location = new System.Drawing.Point(off_x, (folders.Count + layers.Count) * panel_height + panel1.AutoScrollPosition.Y );
            //System.Diagnostics.Debug.WriteLine(panel1.AutoScrollPosition);

            panels.Add(fp);
            UpdateList();
            panel1.Controls.Add(fp);
            //vScrollBar1.Maximum = (layers.Count + folders.Count) * panel_height < panel1.Height ? 0 : (layers.Count + folders.Count) * panel_height - panel1.Height;
            
            //Select_entity.Invoke(this, new EventArgs())
        }

        private void add_folder_Click(object sender, EventArgs e)
        {
            string str = $"Folder {CountFolders() + 1}";
            AddFolder(str, CountFolders() + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // AddLayer();
            string str = $"Folder {CountLayers() + 1}";
            AddLayer(str, CountLayers() + 1);
        }

        public void OpenFolder(FolderPanel folder)
        {
            UpdateList();
        }

        private Panel GetPanel(Point pos)
        {
            foreach (var p in panels)
            {
                if (pos.X > p.Location.X && pos.X < p.Location.X + panel_width
                    && pos.Y > p.Location.Y && pos.Y < p.Location.Y + panel_height && p.Visible)
                    return p;
            }
            return null;
        }

        private void AddChilds(List<Panel> childs, FolderPanel parent)
        {
            parent.AddChilds(childs);
        }

        public void RemovePanel(Panel remove)
        {
                panels.Remove(remove);
            remove.Visible = false;
        }
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO: set new current
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_start_pos = e.Location;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_end_pos = e.Location;
            if (mouse_start_pos == mouse_end_pos)
            {
                Panel p = GetPanel(mouse_start_pos);
                if (p != null)
                    p.ChangeSelection();
                return;
            }
            Panel parent = GetPanel(mouse_end_pos);

            List<Panel> childs = SelectedPanels;
            if (parent != null && childs.Count != 0 && parent is FolderPanel && !parent.IsSelected)
            {
                AddChilds(childs,(FolderPanel)parent);
                //UpdateList();
                UpdateList();
            }
        }

        private void DocumentStructureViewer_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void DocumentStructureViewer_MouseUp(object sender, MouseEventArgs e)
        {

        }


    }
}
