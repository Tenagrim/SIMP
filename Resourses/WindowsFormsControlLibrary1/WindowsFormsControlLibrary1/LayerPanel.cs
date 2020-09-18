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
    public partial class LayerPanel : Panel
    {

        public LayerPanel(string name, DocumentStructureViewer sParent, int id) : this()
        {
            Name = name;
            this.id = id;
            superParent = sParent;
        }
        public LayerPanel()
        {
            InitializeComponent();
            //ControlExtension.Draggable(this, true);
            Parent = null;
        }
    }
}
