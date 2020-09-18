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


    public partial class DocumentStructureViewer: UserControl
    {
        public List<Panel> SelectedPanels { get { return (from p in panels where p.IsSelected select p).ToList(); } }

        private List<Panel> panels;
        private int off_x = 2;
        private int off_y = 3;
        private int panel_height = 43;

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
                foreach (var f in folder.ChildFolders)
                    DisplayFolder(f, ref pos);
                foreach(var l in folder.ChildLayers)
                    l.Location = new Point(off_x, off_y + pos++ * panel_height + panel1.AutoScrollPosition.Y);
            }
        }

        private void UpdateList()
        {
            int pos = 0;

            foreach (var p in panels)
                if (p is FolderPanel)
                DisplayFolder((FolderPanel)p, ref pos);
            foreach (var l in panels)
                if (l is LayerPanel)
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

        public string AddFolder()
        {
            string str = $"Folder {CountFolders() + 1}";

            FolderPanel fp = new FolderPanel(str, this,panels.Count );
            //fp.Location = new System.Drawing.Point(off_x, folders.Count * panel_height + panel1.AutoScrollPosition.Y);
            //foreach(var l in layers)
            //    l.Location = new System.Drawing.Point(off_x, (folders.Count + layers.IndexOf(l)) * panel_height + panel1.AutoScrollPosition.Y);

            panels.Add(fp);
            UpdateList();           
            panel1.Controls.Add(fp);

            //vScrollBar1.Maximum = (layers.Count + folders.Count) * panel_height < panel1.Height? 0 : (layers.Count + folders.Count) * panel_height - panel1.Height;
            return str;
        }

        public string AddLayer()
        {
            string str = $"Layer {CountLayers() + 1}";

            LayerPanel fp = new LayerPanel(str, panels.Count());
            //fp.Location = new System.Drawing.Point(off_x, (folders.Count + layers.Count) * panel_height + panel1.AutoScrollPosition.Y );
            //System.Diagnostics.Debug.WriteLine(panel1.AutoScrollPosition);

            panels.Add(fp);
            UpdateList();
            panel1.Controls.Add(fp);
            //vScrollBar1.Maximum = (layers.Count + folders.Count) * panel_height < panel1.Height ? 0 : (layers.Count + folders.Count) * panel_height - panel1.Height;
            
            return str;
        }

        private void add_folder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddLayer();
        }

        public void OpenFolder(FolderPanel folder)
        {
            UpdateList();
        }

        private void MakeChilds()
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_start_pos = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_end_pos = e.Location;
            if (mouse_start_pos == mouse_end_pos)
                return;


        }
    }
}
