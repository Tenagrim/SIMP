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

        public LayerPanel(string name, int id) : this()
        {
            Name = name;
            this.id = id;
        }
        public LayerPanel()
        {
            InitializeComponent();
            //ControlExtension.Draggable(this, true);
        }
    }
}
