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
        public event DocumentStructureHandler OnSetCurrentEntity;

        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnAddChilds;

        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnVisibleChanged_;
        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnDeleteChilds;
        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnUnsetChilds;
        [Browsable(true), Category("Action")]
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnDeleteEntity;
        [Description("Invoked when new childs for folder was set")]
        public event DocumentStructureHandler OnDeleteEnties;

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
                if (p is FolderPanel && p.Parent_ == null)
                    DisplayFolder((FolderPanel)p, ref pos);
            foreach (var l in panels)
                if (l is LayerPanel && l.Parent_ == null)
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

            FolderPanel fp = new FolderPanel(name, this, id);
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

            LayerPanel fp = new LayerPanel(name, this, id);
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
            AddFolder(str, panels.Count + 1);
        }

        public void VisibleChanged_(Panel sender)
        {
            DocumentStructureArgs args = new DocumentStructureArgs(null, sender.ID, -1, sender.IsVisible);
            if (OnVisibleChanged_ != null)
                OnVisibleChanged_.Invoke(this, args);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // AddLayer();
            string str = $"Layer {CountLayers() + 1}";
            AddLayer(str, panels.Count + 1);
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

        private Panel GetPanel(int id)
        {
            var sel = from p in panels
                      where p.ID == id
                      select p;
            if (sel.Count() == 0)
                return null;
            else
                return sel.First();
        }

        private void AddChilds(List<Panel> childs, FolderPanel parent)
        {
            int[] sel = GetIds(childs);

            DocumentStructureArgs args = new DocumentStructureArgs(sel, -1, parent.ID, false);
            parent.AddChilds(childs);
            if (OnAddChilds != null)
                OnAddChilds.Invoke(this, args);
        }
        public void AddChild(int id, int parent_id)
        {
            Panel parent = GetPanel(parent_id);
            Panel child = GetPanel(id);
            if (parent == null || child == null || !(parent is FolderPanel))
                throw new ArgumentException();
            ((FolderPanel)parent).AddChilds(child);
        }

        public void UnsetChilds(List<Panel> childs)
        {
            foreach (var c in childs)
            {
                c.RemoveMe();
                c.Parent_ = null;
                c.ChangeSelection();
            }

            if (OnUnsetChilds != null)
            {
                var child_ids = (from c in childs
                                 select c.ID).ToArray();
                DocumentStructureArgs args = new DocumentStructureArgs(child_ids, -1, -1, false);
                OnUnsetChilds.Invoke(this, args);
            }
        }

        public void RemovePanel(Panel remove)
        {
            panels.Remove(remove);
            remove.Visible = false;
        }
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Panel p = GetPanel(e.Location);
            if (p != null)
            {
                if (currentEntity != null)
                    currentEntity.ChangeIsCurrent();
                currentEntity = p;
                currentEntity.ChangeIsCurrent();
                DocumentStructureArgs args = new DocumentStructureArgs(null, p.ID, -1, p.IsVisible);
                if (OnSetCurrentEntity != null)
                    OnSetCurrentEntity.Invoke(this, args);
            }
        }

        public void SetCurrentEntity(int id)
        {
            var res = from p in panels
                      where p.ID == id
                      select p;
            if (res.Count() != 0)
            {
                if (currentEntity != null)
                    currentEntity.ChangeIsCurrent();
                currentEntity = res.First();
                currentEntity.ChangeIsCurrent();

                //currentEntity = res.First();
            }
        }

        public void ClearPanel()
        {
            panels.Clear();
            panel1.Controls.Clear();
        }

        public void DeletePanel(int id)
        {
            Panel del = GetPanel(id);
            if (del == null)
                return;
            DeletePanel(del);
        }
        private void DeletePanel(Panel del)
        {
            if (del is FolderPanel)
                DeleteChilds(del.ID);

            panels.Remove(del);
            panel1.Controls.Remove(del);
            del.RemoveMe();
            del.Dispose();
            UpdateList();
            DocumentStructureArgs args = new DocumentStructureArgs(null, del.ID, -1, false);
            if (OnDeleteEntity != null)
                OnDeleteEntity.Invoke(this, args);
        }



        public void DeleteSelected()
        {
            if (SelectedPanels.Count == 0)
                return;

            int[] selected = GetIds(SelectedPanels);

            DocumentStructureArgs args = new DocumentStructureArgs(selected, -1, -1, false);
            foreach (var p in SelectedPanels)
                DeletePanel(p);
            if (OnDeleteEnties != null)
                OnDeleteEnties.Invoke(this, args);

        }

        private int[] GetIds(List<Panel> list)
        {
            return (from p in list
                       select p.ID).ToArray();
        }

        private void DeleteChilds(int id)
        {
            List<Panel> childs = GetChilds(id);
            var child_ids = (from c in childs
                             select c.ID).ToArray();
            if (childs == null)
                return;
            DocumentStructureArgs args = new DocumentStructureArgs(child_ids, id, -1, false);

            foreach (var c in childs)
            {
                panels.Remove(c);
                panel1.Controls.Remove((Control)c);
                c.Dispose();
            }
            if (OnDeleteChilds != null)
                OnDeleteChilds.Invoke(this, args);
        }

        private List<Panel> GetChilds(int id)
        {
            Panel parent = GetPanel(id);
            if (!(parent is FolderPanel))
                return null;
            else
                return ((FolderPanel)parent).Childs;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_start_pos = e.Location;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_end_pos = e.Location;
            if (mouse_start_pos == mouse_end_pos && e.Button == MouseButtons.Right)
            {
                Panel p = GetPanel(mouse_start_pos);
                if (p != null)
                    p.ChangeSelection();
                return;
            }
            Panel parent = GetPanel(mouse_end_pos);

            List<Panel> childs = SelectedPanels;
            if ( childs.Count != 0 )
            {
                if (parent != null && parent is FolderPanel && !parent.IsSelected)
                    AddChilds(childs, (FolderPanel)parent);
                else
                    UnsetChilds(childs);
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
