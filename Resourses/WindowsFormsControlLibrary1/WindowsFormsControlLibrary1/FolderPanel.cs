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


        public List<FolderPanel> ChildFolders { get; set; }
        public List<LayerPanel> ChildLayers{ get; set; }
        public FolderPanel Parent { get { return parent; } }


        public FolderPanel parent;
        public bool IsOpened { get { return opened; } }

        private DocumentStructureViewer superParent;
        private bool opened;
        public FolderPanel(string name, DocumentStructureViewer sParent, int id) : this()
        {
            Name = name;
            superParent = sParent;
            this.id = id;
        }
        public FolderPanel()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.folder_closed;
            opened = false;
            Name = "Folder";
            ChildFolders = new List<FolderPanel>();
            ChildLayers = new List<LayerPanel>();
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
    }
}
