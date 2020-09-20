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
    public partial class FolderPanel : Panel
    {
        //private delegate void OpenCloseFolderHandler(FolderPanel folder);


        public List<Panel> Childs { get; set; }

        //public FolderPanel parent;
        public bool IsOpened { get { return opened; } set { 
                opened = value;
                pictureBox1.Image = opened ? Properties.Resources.folder_opened : Properties.Resources.folder_closed;
            } }


        private bool opened;
        public FolderPanel(string name, DocumentStructureViewer sParent, int id) : this()
        {
            Name_ = name;
            superParent = sParent;
            this.id = id;
        }
        public FolderPanel()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.folder_closed;
            opened = false;
            Name_ = "Folder";
            Childs = new List<Panel>();
            Parent_ = null;
            isCurrent = false;
            //ControlExtension.Draggable(this, true);
        }
        public void ChangeOpened()
        {
            opened = !opened;
            pictureBox1.Image = opened ? Properties.Resources.folder_opened : Properties.Resources.folder_closed;
            superParent.OpenFolder(this);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangeOpened();
        }

        public void AddChilds(List<Panel> new_childs)
        {
            foreach (var c in new_childs)
            {
                AddChilds(c);
                c.ChangeSelection();
            }
        }
        public void AddChilds(Panel c)
        {
                c.RemoveMe();
                Childs.Add(c);
                c.Parent_ = this;
        }

        public void RemoveChild(Panel child)
        {
            Childs.Remove(child);
        }

        public void HideChilds()
        {
            foreach (var c in Childs)
            {
                FolderPanel f = c as FolderPanel;

                if (f != null && f.IsOpened)
                    f.HideChilds();
                c.Visible = false;
            }
        }
    }
}
